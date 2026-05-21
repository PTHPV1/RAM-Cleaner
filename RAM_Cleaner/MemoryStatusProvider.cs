using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RAM_Cleaner
{
    internal sealed class MemoryStatusProvider
    {
        public MemorySnapshot GetSnapshot()
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            memoryStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (!GlobalMemoryStatusEx(ref memoryStatus))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return new MemorySnapshot(
                memoryStatus.ullTotalPhys,
                memoryStatus.ullAvailPhys,
                memoryStatus.ullTotalPageFile,
                memoryStatus.ullAvailPageFile,
                (int)memoryStatus.dwMemoryLoad);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }
    }

    internal sealed class MemorySnapshot
    {
        public MemorySnapshot(
            ulong totalPhysicalBytes,
            ulong availablePhysicalBytes,
            ulong totalPageFileBytes,
            ulong availablePageFileBytes,
            int memoryLoadPercent)
        {
            TotalPhysicalBytes = totalPhysicalBytes;
            AvailablePhysicalBytes = availablePhysicalBytes;
            TotalPageFileBytes = totalPageFileBytes;
            AvailablePageFileBytes = availablePageFileBytes;
            MemoryLoadPercent = memoryLoadPercent;
        }

        public ulong TotalPhysicalBytes { get; private set; }

        public ulong AvailablePhysicalBytes { get; private set; }

        public ulong UsedPhysicalBytes
        {
            get { return TotalPhysicalBytes - AvailablePhysicalBytes; }
        }

        public ulong TotalPageFileBytes { get; private set; }

        public ulong AvailablePageFileBytes { get; private set; }

        public int MemoryLoadPercent { get; private set; }
    }
}
