using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace RAM_Cleaner
{
    internal sealed class RamCleanerService
    {
        private const int SystemMemoryListInformation = 80;
        private const int MemoryPurgeStandbyListCommand = 4;
        private const int TokenAdjustPrivileges = 0x20;
        private const int TokenQuery = 0x8;
        private const int SePrivilegeEnabled = 0x2;
        private const int ErrorNotAllAssigned = 1300;
        private const uint ProcessQueryInformation = 0x0400;
        private const uint ProcessSetQuota = 0x0100;

        public bool IsRunningAsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public SmartCleanResult SmartClean()
        {
            WorkingSetTrimResult trimResult = TrimProcessWorkingSets();
            OperationResult standbyResult = PurgeStandbyList();
            return new SmartCleanResult(trimResult, standbyResult);
        }

        public WorkingSetTrimResult TrimProcessWorkingSets()
        {
            int trimmedProcesses = 0;
            int skippedProcesses = 0;
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    if (process.Id == 0)
                    {
                        skippedProcesses++;
                        continue;
                    }

                    IntPtr processHandle = OpenProcess(ProcessQueryInformation | ProcessSetQuota, false, process.Id);

                    if (processHandle == IntPtr.Zero)
                    {
                        skippedProcesses++;
                        continue;
                    }

                    try
                    {
                        if (EmptyWorkingSet(processHandle))
                        {
                            trimmedProcesses++;
                        }
                        else
                        {
                            skippedProcesses++;
                        }
                    }
                    finally
                    {
                        CloseHandle(processHandle);
                    }
                }
                catch
                {
                    skippedProcesses++;
                }
                finally
                {
                    process.Dispose();
                }
            }

            bool succeeded = trimmedProcesses > 0;
            string message = string.Format(
                "ลด Working Set เสร็จแล้ว ทำงานได้กับ {0} โปรเซส และข้ามไป {1} โปรเซส",
                trimmedProcesses,
                skippedProcesses);

            return new WorkingSetTrimResult(succeeded, message, trimmedProcesses, skippedProcesses);
        }

        public OperationResult PurgeStandbyList()
        {
            if (!IsRunningAsAdministrator())
            {
                return new OperationResult(false, "การล้าง Standby List ต้องใช้สิทธิ์ผู้ดูแลระบบ กรุณากดเปิดใหม่แบบผู้ดูแลระบบแล้วลองอีกครั้ง");
            }

            try
            {
                EnablePrivilege("SeProfileSingleProcessPrivilege");

                int command = MemoryPurgeStandbyListCommand;
                int status = NtSetSystemInformation(SystemMemoryListInformation, ref command, Marshal.SizeOf(typeof(int)));

                if (status != 0)
                {
                    return new OperationResult(false, string.Format("ล้าง Standby List ไม่สำเร็จ รหัส NTSTATUS คือ 0x{0:X8}", status));
                }

                return new OperationResult(true, "ล้าง Standby List เสร็จแล้ว");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, "ล้าง Standby List ไม่สำเร็จ: " + ex.Message);
            }
        }

        private static void EnablePrivilege(string privilegeName)
        {
            IntPtr tokenHandle;

            using (Process currentProcess = Process.GetCurrentProcess())
            {
                if (!OpenProcessToken(currentProcess.Handle, TokenAdjustPrivileges | TokenQuery, out tokenHandle))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }

            try
            {
                LUID luid;

                if (!LookupPrivilegeValue(null, privilegeName, out luid))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                TOKEN_PRIVILEGES privileges = new TOKEN_PRIVILEGES();
                privileges.PrivilegeCount = 1;
                privileges.Privileges = new LUID_AND_ATTRIBUTES();
                privileges.Privileges.Luid = luid;
                privileges.Privileges.Attributes = SePrivilegeEnabled;

                if (!AdjustTokenPrivileges(tokenHandle, false, ref privileges, 0, IntPtr.Zero, IntPtr.Zero))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                int lastError = Marshal.GetLastWin32Error();

                if (lastError == ErrorNotAllAssigned)
                {
                    throw new InvalidOperationException("สิทธิ์ของ Windows ที่จำเป็นไม่พร้อมใช้งานในเซสชันนี้");
                }

                if (lastError != 0)
                {
                    throw new Win32Exception(lastError);
                }
            }
            finally
            {
                CloseHandle(tokenHandle);
            }
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AdjustTokenPrivileges(
            IntPtr tokenHandle,
            [MarshalAs(UnmanagedType.Bool)] bool disableAllPrivileges,
            ref TOKEN_PRIVILEGES newState,
            int bufferLength,
            IntPtr previousState,
            IntPtr returnLength);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenProcessToken(IntPtr processHandle, int desiredAccess, out IntPtr tokenHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint desiredAccess, [MarshalAs(UnmanagedType.Bool)] bool inheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EmptyWorkingSet(IntPtr process);

        [DllImport("ntdll.dll")]
        private static extern int NtSetSystemInformation(int systemInformationClass, ref int systemInformation, int systemInformationLength);

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public int Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct TOKEN_PRIVILEGES
        {
            public int PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privileges;
        }
    }

    internal class OperationResult
    {
        public OperationResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; private set; }

        public string Message { get; private set; }
    }

    internal sealed class WorkingSetTrimResult : OperationResult
    {
        public WorkingSetTrimResult(bool succeeded, string message, int trimmedProcesses, int skippedProcesses)
            : base(succeeded, message)
        {
            TrimmedProcesses = trimmedProcesses;
            SkippedProcesses = skippedProcesses;
        }

        public int TrimmedProcesses { get; private set; }

        public int SkippedProcesses { get; private set; }
    }

    internal sealed class SmartCleanResult : OperationResult
    {
        public SmartCleanResult(WorkingSetTrimResult workingSetTrimResult, OperationResult standbyPurgeResult)
            : base(
                workingSetTrimResult.Succeeded || standbyPurgeResult.Succeeded,
                workingSetTrimResult.Message + Environment.NewLine + standbyPurgeResult.Message)
        {
            WorkingSetTrimResult = workingSetTrimResult;
            StandbyPurgeResult = standbyPurgeResult;
        }

        public WorkingSetTrimResult WorkingSetTrimResult { get; private set; }

        public OperationResult StandbyPurgeResult { get; private set; }
    }
}
