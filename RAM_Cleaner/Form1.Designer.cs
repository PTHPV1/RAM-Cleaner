namespace RAM_Cleaner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblAdminState = new System.Windows.Forms.Label();
            this.lblMemorySummary = new System.Windows.Forms.Label();
            this.progressMemory = new System.Windows.Forms.ProgressBar();
            this.grpMemoryStats = new System.Windows.Forms.GroupBox();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblLastRefreshValue = new System.Windows.Forms.Label();
            this.lblLastRefreshLabel = new System.Windows.Forms.Label();
            this.lblPageFileValue = new System.Windows.Forms.Label();
            this.lblPageFileLabel = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblAvailableValue = new System.Windows.Forms.Label();
            this.lblAvailableLabel = new System.Windows.Forms.Label();
            this.lblUsedValue = new System.Windows.Forms.Label();
            this.lblUsedLabel = new System.Windows.Forms.Label();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.lblActionHint = new System.Windows.Forms.Label();
            this.btnRestartAsAdmin = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPurgeStandby = new System.Windows.Forms.Button();
            this.btnTrimWorkingSets = new System.Windows.Forms.Button();
            this.btnSmartClean = new System.Windows.Forms.Button();
            this.grpActivity = new System.Windows.Forms.GroupBox();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.grpMemoryStats.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.grpActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(22, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(226, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "เครื่องมือเคลียร์ RAM";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(25, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(324, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "ลดการใช้หน่วยความจำของโปรเซสและล้าง Standby List บน Windows";
            // 
            // lblAdminState
            // 
            this.lblAdminState.Location = new System.Drawing.Point(523, 24);
            this.lblAdminState.Name = "lblAdminState";
            this.lblAdminState.Size = new System.Drawing.Size(325, 24);
            this.lblAdminState.TabIndex = 2;
            this.lblAdminState.Text = "สถานะสิทธิ์ผู้ดูแลระบบ";
            this.lblAdminState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMemorySummary
            // 
            this.lblMemorySummary.AutoSize = true;
            this.lblMemorySummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMemorySummary.Location = new System.Drawing.Point(24, 92);
            this.lblMemorySummary.Name = "lblMemorySummary";
            this.lblMemorySummary.Size = new System.Drawing.Size(236, 19);
            this.lblMemorySummary.TabIndex = 3;
            this.lblMemorySummary.Text = "หน่วยความจำที่ใช้อยู่: 0 GB จาก 0 GB";
            // 
            // progressMemory
            // 
            this.progressMemory.Location = new System.Drawing.Point(28, 119);
            this.progressMemory.Name = "progressMemory";
            this.progressMemory.Size = new System.Drawing.Size(820, 20);
            this.progressMemory.TabIndex = 4;
            // 
            // grpMemoryStats
            // 
            this.grpMemoryStats.Controls.Add(this.lblStatusValue);
            this.grpMemoryStats.Controls.Add(this.lblStatusLabel);
            this.grpMemoryStats.Controls.Add(this.lblLastRefreshValue);
            this.grpMemoryStats.Controls.Add(this.lblLastRefreshLabel);
            this.grpMemoryStats.Controls.Add(this.lblPageFileValue);
            this.grpMemoryStats.Controls.Add(this.lblPageFileLabel);
            this.grpMemoryStats.Controls.Add(this.lblTotalValue);
            this.grpMemoryStats.Controls.Add(this.lblTotalLabel);
            this.grpMemoryStats.Controls.Add(this.lblAvailableValue);
            this.grpMemoryStats.Controls.Add(this.lblAvailableLabel);
            this.grpMemoryStats.Controls.Add(this.lblUsedValue);
            this.grpMemoryStats.Controls.Add(this.lblUsedLabel);
            this.grpMemoryStats.Location = new System.Drawing.Point(28, 160);
            this.grpMemoryStats.Name = "grpMemoryStats";
            this.grpMemoryStats.Size = new System.Drawing.Size(402, 188);
            this.grpMemoryStats.TabIndex = 5;
            this.grpMemoryStats.TabStop = false;
            this.grpMemoryStats.Text = "สรุปหน่วยความจำ";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoEllipsis = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(144, 146);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(240, 18);
            this.lblStatusValue.TabIndex = 11;
            this.lblStatusValue.Text = "พร้อมใช้งาน";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatusLabel.Location = new System.Drawing.Point(20, 147);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(39, 15);
            this.lblStatusLabel.TabIndex = 10;
            this.lblStatusLabel.Text = "สถานะ:";
            // 
            // lblLastRefreshValue
            // 
            this.lblLastRefreshValue.AutoSize = true;
            this.lblLastRefreshValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLastRefreshValue.Location = new System.Drawing.Point(144, 120);
            this.lblLastRefreshValue.Name = "lblLastRefreshValue";
            this.lblLastRefreshValue.Size = new System.Drawing.Size(55, 15);
            this.lblLastRefreshValue.TabIndex = 9;
            this.lblLastRefreshValue.Text = "00:00:00";
            // 
            // lblLastRefreshLabel
            // 
            this.lblLastRefreshLabel.AutoSize = true;
            this.lblLastRefreshLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblLastRefreshLabel.Location = new System.Drawing.Point(20, 120);
            this.lblLastRefreshLabel.Name = "lblLastRefreshLabel";
            this.lblLastRefreshLabel.Size = new System.Drawing.Size(64, 15);
            this.lblLastRefreshLabel.TabIndex = 8;
            this.lblLastRefreshLabel.Text = "อัปเดตล่าสุด:";
            // 
            // lblPageFileValue
            // 
            this.lblPageFileValue.AutoSize = true;
            this.lblPageFileValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPageFileValue.Location = new System.Drawing.Point(144, 94);
            this.lblPageFileValue.Name = "lblPageFileValue";
            this.lblPageFileValue.Size = new System.Drawing.Size(72, 15);
            this.lblPageFileValue.TabIndex = 7;
            this.lblPageFileValue.Text = "0 GB / 0 GB";
            // 
            // lblPageFileLabel
            // 
            this.lblPageFileLabel.AutoSize = true;
            this.lblPageFileLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblPageFileLabel.Location = new System.Drawing.Point(20, 94);
            this.lblPageFileLabel.Name = "lblPageFileLabel";
            this.lblPageFileLabel.Size = new System.Drawing.Size(82, 15);
            this.lblPageFileLabel.TabIndex = 6;
            this.lblPageFileLabel.Text = "Page File ที่ว่าง:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(144, 68);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(34, 15);
            this.lblTotalValue.TabIndex = 5;
            this.lblTotalValue.Text = "0 GB";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 68);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(72, 15);
            this.lblTotalLabel.TabIndex = 4;
            this.lblTotalLabel.Text = "RAM ทั้งหมด:";
            // 
            // lblAvailableValue
            // 
            this.lblAvailableValue.AutoSize = true;
            this.lblAvailableValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvailableValue.Location = new System.Drawing.Point(144, 42);
            this.lblAvailableValue.Name = "lblAvailableValue";
            this.lblAvailableValue.Size = new System.Drawing.Size(34, 15);
            this.lblAvailableValue.TabIndex = 3;
            this.lblAvailableValue.Text = "0 GB";
            // 
            // lblAvailableLabel
            // 
            this.lblAvailableLabel.AutoSize = true;
            this.lblAvailableLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblAvailableLabel.Location = new System.Drawing.Point(20, 42);
            this.lblAvailableLabel.Name = "lblAvailableLabel";
            this.lblAvailableLabel.Size = new System.Drawing.Size(54, 15);
            this.lblAvailableLabel.TabIndex = 2;
            this.lblAvailableLabel.Text = "RAM ว่าง:";
            // 
            // lblUsedValue
            // 
            this.lblUsedValue.AutoSize = true;
            this.lblUsedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsedValue.Location = new System.Drawing.Point(144, 18);
            this.lblUsedValue.Name = "lblUsedValue";
            this.lblUsedValue.Size = new System.Drawing.Size(34, 15);
            this.lblUsedValue.TabIndex = 1;
            this.lblUsedValue.Text = "0 GB";
            // 
            // lblUsedLabel
            // 
            this.lblUsedLabel.AutoSize = true;
            this.lblUsedLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsedLabel.Location = new System.Drawing.Point(20, 18);
            this.lblUsedLabel.Name = "lblUsedLabel";
            this.lblUsedLabel.Size = new System.Drawing.Size(70, 15);
            this.lblUsedLabel.TabIndex = 0;
            this.lblUsedLabel.Text = "RAM ที่ใช้อยู่:";
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.lblActionHint);
            this.grpActions.Controls.Add(this.btnRestartAsAdmin);
            this.grpActions.Controls.Add(this.btnRefresh);
            this.grpActions.Controls.Add(this.btnPurgeStandby);
            this.grpActions.Controls.Add(this.btnTrimWorkingSets);
            this.grpActions.Controls.Add(this.btnSmartClean);
            this.grpActions.Location = new System.Drawing.Point(446, 160);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(402, 188);
            this.grpActions.TabIndex = 6;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "คำสั่งทำความสะอาด";
            // 
            // lblActionHint
            // 
            this.lblActionHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblActionHint.Location = new System.Drawing.Point(23, 111);
            this.lblActionHint.Name = "lblActionHint";
            this.lblActionHint.Size = new System.Drawing.Size(352, 31);
            this.lblActionHint.TabIndex = 5;
            this.lblActionHint.Text = "โหมดอัตโนมัติจะทำทั้งสองขั้นตอน ส่วนการล้าง Standby List มักต้องใช้สิทธิ์ผู้ดูแลร" +
    "ะบบ";
            // 
            // btnRestartAsAdmin
            // 
            this.btnRestartAsAdmin.Location = new System.Drawing.Point(206, 66);
            this.btnRestartAsAdmin.Name = "btnRestartAsAdmin";
            this.btnRestartAsAdmin.Size = new System.Drawing.Size(168, 30);
            this.btnRestartAsAdmin.TabIndex = 4;
            this.btnRestartAsAdmin.Text = "เปิดใหม่แบบผู้ดูแลระบบ";
            this.btnRestartAsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(23, 66);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(168, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "รีเฟรชข้อมูล";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnPurgeStandby
            // 
            this.btnPurgeStandby.Location = new System.Drawing.Point(206, 22);
            this.btnPurgeStandby.Name = "btnPurgeStandby";
            this.btnPurgeStandby.Size = new System.Drawing.Size(168, 30);
            this.btnPurgeStandby.TabIndex = 2;
            this.btnPurgeStandby.Text = "ล้าง Standby List";
            this.btnPurgeStandby.UseVisualStyleBackColor = true;
            // 
            // btnTrimWorkingSets
            // 
            this.btnTrimWorkingSets.Location = new System.Drawing.Point(23, 22);
            this.btnTrimWorkingSets.Name = "btnTrimWorkingSets";
            this.btnTrimWorkingSets.Size = new System.Drawing.Size(168, 30);
            this.btnTrimWorkingSets.TabIndex = 1;
            this.btnTrimWorkingSets.Text = "ลด Working Set";
            this.btnTrimWorkingSets.UseVisualStyleBackColor = true;
            // 
            // btnSmartClean
            // 
            this.btnSmartClean.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSmartClean.Location = new System.Drawing.Point(23, 146);
            this.btnSmartClean.Name = "btnSmartClean";
            this.btnSmartClean.Size = new System.Drawing.Size(351, 30);
            this.btnSmartClean.TabIndex = 0;
            this.btnSmartClean.Text = "ทำความสะอาดอัตโนมัติ";
            this.btnSmartClean.UseVisualStyleBackColor = true;
            // 
            // grpActivity
            // 
            this.grpActivity.Controls.Add(this.txtActivity);
            this.grpActivity.Location = new System.Drawing.Point(28, 367);
            this.grpActivity.Name = "grpActivity";
            this.grpActivity.Size = new System.Drawing.Size(820, 185);
            this.grpActivity.TabIndex = 7;
            this.grpActivity.TabStop = false;
            this.grpActivity.Text = "บันทึกการทำงาน";
            // 
            // txtActivity
            // 
            this.txtActivity.BackColor = System.Drawing.Color.White;
            this.txtActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActivity.Location = new System.Drawing.Point(20, 24);
            this.txtActivity.Multiline = true;
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.ReadOnly = true;
            this.txtActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActivity.Size = new System.Drawing.Size(780, 140);
            this.txtActivity.TabIndex = 0;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 3000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(878, 574);
            this.Controls.Add(this.grpActivity);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpMemoryStats);
            this.Controls.Add(this.progressMemory);
            this.Controls.Add(this.lblMemorySummary);
            this.Controls.Add(this.lblAdminState);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เครื่องมือเคลียร์ RAM";
            this.grpMemoryStats.ResumeLayout(false);
            this.grpMemoryStats.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpActivity.ResumeLayout(false);
            this.grpActivity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPurgeStandby;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRestartAsAdmin;
        private System.Windows.Forms.Button btnSmartClean;
        private System.Windows.Forms.Button btnTrimWorkingSets;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.GroupBox grpActivity;
        private System.Windows.Forms.GroupBox grpMemoryStats;
        private System.Windows.Forms.Label lblActionHint;
        private System.Windows.Forms.Label lblAdminState;
        private System.Windows.Forms.Label lblAvailableLabel;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Label lblLastRefreshLabel;
        private System.Windows.Forms.Label lblLastRefreshValue;
        private System.Windows.Forms.Label lblMemorySummary;
        private System.Windows.Forms.Label lblPageFileLabel;
        private System.Windows.Forms.Label lblPageFileValue;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblUsedLabel;
        private System.Windows.Forms.Label lblUsedValue;
        private System.Windows.Forms.ProgressBar progressMemory;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.TextBox txtActivity;
    }
}
