using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAM_Cleaner
{
    public partial class Form1 : Form
    {
        private readonly MemoryStatusProvider _memoryStatusProvider;
        private readonly RamCleanerService _ramCleanerService;
        private bool _isBusy;

        public Form1()
        {
            InitializeComponent();
            _memoryStatusProvider = new MemoryStatusProvider();
            _ramCleanerService = new RamCleanerService();

            Load += Form1_Load;
            btnSmartClean.Click += btnSmartClean_Click;
            btnTrimWorkingSets.Click += btnTrimWorkingSets_Click;
            btnPurgeStandby.Click += btnPurgeStandby_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnRestartAsAdmin.Click += btnRestartAsAdmin_Click;
            refreshTimer.Tick += refreshTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAdminState();
            RefreshDashboard();
            AppendLog("แอปพร้อมใช้งาน");
            AppendLog("โหมดทำความสะอาดอัตโนมัติจะลด Working Set ของโปรเซสและล้าง Standby List เมื่อรันด้วยสิทธิ์ผู้ดูแลระบบ");
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                return;
            }

            RefreshDashboard();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private async void btnSmartClean_Click(object sender, EventArgs e)
        {
            await RunSmartCleanAsync();
        }

        private async void btnTrimWorkingSets_Click(object sender, EventArgs e)
        {
            await RunWorkingSetTrimAsync();
        }

        private async void btnPurgeStandby_Click(object sender, EventArgs e)
        {
            await RunStandbyPurgeAsync();
        }

        private void btnRestartAsAdmin_Click(object sender, EventArgs e)
        {
            RestartAsAdministrator();
        }

        private async Task RunSmartCleanAsync()
        {
            if (_isBusy)
            {
                return;
            }

            SetBusyState(true, "กำลังทำความสะอาดอัตโนมัติ...");
            AppendLog("เริ่มทำความสะอาดอัตโนมัติ");

            try
            {
                SmartCleanResult result = await Task.Run(() => _ramCleanerService.SmartClean());
                AppendLog(result.Message);
                SetStatus(result.Succeeded ? "ทำความสะอาดอัตโนมัติเสร็จแล้ว" : "ทำความสะอาดอัตโนมัติเสร็จแล้วพร้อมคำเตือน");
            }
            catch (Exception ex)
            {
                HandleOperationError("การทำความสะอาดอัตโนมัติล้มเหลว", ex);
            }
            finally
            {
                FinishBackgroundOperation();
            }
        }

        private async Task RunWorkingSetTrimAsync()
        {
            if (_isBusy)
            {
                return;
            }

            SetBusyState(true, "กำลังลด Working Set ของโปรเซส...");
            AppendLog("เริ่มลด Working Set");

            try
            {
                WorkingSetTrimResult result = await Task.Run(() => _ramCleanerService.TrimProcessWorkingSets());
                AppendLog(result.Message);
                SetStatus(result.Succeeded ? "ลด Working Set เสร็จแล้ว" : "ลด Working Set เสร็จแล้วพร้อมคำเตือน");
            }
            catch (Exception ex)
            {
                HandleOperationError("การลด Working Set ล้มเหลว", ex);
            }
            finally
            {
                FinishBackgroundOperation();
            }
        }

        private async Task RunStandbyPurgeAsync()
        {
            if (_isBusy)
            {
                return;
            }

            SetBusyState(true, "กำลังล้าง Standby List...");
            AppendLog("เริ่มล้าง Standby List");

            try
            {
                OperationResult result = await Task.Run(() => _ramCleanerService.PurgeStandbyList());
                AppendLog(result.Message);
                SetStatus(result.Succeeded ? "ล้าง Standby List เสร็จแล้ว" : "ล้าง Standby List เสร็จแล้วพร้อมคำเตือน");
            }
            catch (Exception ex)
            {
                HandleOperationError("การล้าง Standby List ล้มเหลว", ex);
            }
            finally
            {
                FinishBackgroundOperation();
            }
        }

        private void FinishBackgroundOperation()
        {
            RefreshDashboard();
            UpdateAdminState();
            SetBusyState(false, "พร้อมใช้งาน");
        }

        private void HandleOperationError(string message, Exception ex)
        {
            SetStatus(message);
            AppendLog(message + " " + ex.Message);
            MessageBox.Show(this, ex.Message, "เครื่องมือเคลียร์ RAM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RefreshDashboard()
        {
            try
            {
                MemorySnapshot snapshot = _memoryStatusProvider.GetSnapshot();
                int memoryLoad = Math.Max(progressMemory.Minimum, Math.Min(progressMemory.Maximum, snapshot.MemoryLoadPercent));

                progressMemory.Value = memoryLoad;
                lblMemorySummary.Text = string.Format(
                    "หน่วยความจำที่ใช้อยู่: {0} จาก {1} ({2}%)",
                    FormatBytes(snapshot.UsedPhysicalBytes),
                    FormatBytes(snapshot.TotalPhysicalBytes),
                    snapshot.MemoryLoadPercent);

                lblUsedValue.Text = FormatBytes(snapshot.UsedPhysicalBytes);
                lblAvailableValue.Text = FormatBytes(snapshot.AvailablePhysicalBytes);
                lblTotalValue.Text = FormatBytes(snapshot.TotalPhysicalBytes);
                lblPageFileValue.Text = string.Format(
                    "{0} free / {1} total",
                    FormatBytes(snapshot.AvailablePageFileBytes),
                    FormatBytes(snapshot.TotalPageFileBytes));
                lblLastRefreshValue.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                AppendLog("ไม่สามารถอัปเดตข้อมูลหน่วยความจำได้: " + ex.Message);
                lblStatusValue.Text = "ไม่สามารถอ่านสถานะหน่วยความจำได้";
            }
        }

        private void UpdateAdminState()
        {
            bool isAdmin = _ramCleanerService.IsRunningAsAdministrator();

            lblAdminState.Text = isAdmin ? "เปิดใช้งานโหมดผู้ดูแลระบบแล้ว" : "การล้าง Standby List ต้องใช้สิทธิ์ผู้ดูแลระบบ";
            lblAdminState.ForeColor = isAdmin ? System.Drawing.Color.FromArgb(36, 92, 56) : System.Drawing.Color.FromArgb(160, 72, 0);
            btnRestartAsAdmin.Enabled = !isAdmin && !_isBusy;
        }

        private void SetBusyState(bool isBusy, string statusMessage)
        {
            _isBusy = isBusy;
            refreshTimer.Enabled = !isBusy;

            btnSmartClean.Enabled = !isBusy;
            btnTrimWorkingSets.Enabled = !isBusy;
            btnPurgeStandby.Enabled = !isBusy;
            btnRefresh.Enabled = !isBusy;
            btnRestartAsAdmin.Enabled = !_ramCleanerService.IsRunningAsAdministrator() && !isBusy;

            SetStatus(statusMessage);
        }

        private void SetStatus(string message)
        {
            lblStatusValue.Text = message;
        }

        private void RestartAsAdministrator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(Application.ExecutablePath);
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";

            try
            {
                Process.Start(startInfo);
                Close();
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223)
                {
                    AppendLog("ยกเลิกการขอสิทธิ์ผู้ดูแลระบบ");
                    SetStatus("ยกเลิกการขอสิทธิ์ผู้ดูแลระบบ");
                    return;
                }

                HandleOperationError("ไม่สามารถเปิดใหม่แบบผู้ดูแลระบบได้", ex);
            }
        }

        private void AppendLog(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            string[] lines = message.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                txtActivity.AppendText(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), line, Environment.NewLine));
            }

            txtActivity.SelectionStart = txtActivity.TextLength;
            txtActivity.ScrollToCaret();
        }

        private static string FormatBytes(ulong bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            double value = bytes;
            int suffixIndex = 0;

            while (value >= 1024d && suffixIndex < suffixes.Length - 1)
            {
                value /= 1024d;
                suffixIndex++;
            }

            return string.Format("{0:0.##} {1}", value, suffixes[suffixIndex]);
        }
    }
}
