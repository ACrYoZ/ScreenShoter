namespace ScreenShoter
{
    partial class frmCapture
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnMakeScreen = new System.Windows.Forms.Button();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnMakeScreenClip = new System.Windows.Forms.Button();
            this.btnMakeScreenArea = new System.Windows.Forms.Button();
            this.btnCaptBackgroung = new System.Windows.Forms.Button();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeScreen
            // 
            this.btnMakeScreen.Location = new System.Drawing.Point(12, 12);
            this.btnMakeScreen.Name = "btnMakeScreen";
            this.btnMakeScreen.Size = new System.Drawing.Size(133, 131);
            this.btnMakeScreen.TabIndex = 0;
            this.btnMakeScreen.Text = "Make screenshot";
            this.btnMakeScreen.UseVisualStyleBackColor = true;
            this.btnMakeScreen.Click += new System.EventHandler(this.btnMakeScreen_Click);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmSettings,
            this.toolStripSeparator1,
            this.tlsmExit});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(181, 76);
            // 
            // tlsmSettings
            // 
            this.tlsmSettings.Name = "tlsmSettings";
            this.tlsmSettings.Size = new System.Drawing.Size(180, 22);
            this.tlsmSettings.Text = "Настройки";
            this.tlsmSettings.Click += new System.EventHandler(this.tlsmSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tlsmExit
            // 
            this.tlsmExit.Name = "tlsmExit";
            this.tlsmExit.Size = new System.Drawing.Size(180, 22);
            this.tlsmExit.Text = "Выход";
            this.tlsmExit.Click += new System.EventHandler(this.tlsmExit_Click);
            // 
            // notifIcon
            // 
            this.notifIcon.Text = "notifyIcon1";
            this.notifIcon.Visible = true;
            // 
            // btnMakeScreenClip
            // 
            this.btnMakeScreenClip.Location = new System.Drawing.Point(151, 12);
            this.btnMakeScreenClip.Name = "btnMakeScreenClip";
            this.btnMakeScreenClip.Size = new System.Drawing.Size(140, 131);
            this.btnMakeScreenClip.TabIndex = 1;
            this.btnMakeScreenClip.Text = "Screenshot from clipboard";
            this.btnMakeScreenClip.UseVisualStyleBackColor = true;
            this.btnMakeScreenClip.Click += new System.EventHandler(this.btnMakeScreenClip_Click);
            // 
            // btnMakeScreenArea
            // 
            this.btnMakeScreenArea.Location = new System.Drawing.Point(12, 149);
            this.btnMakeScreenArea.Name = "btnMakeScreenArea";
            this.btnMakeScreenArea.Size = new System.Drawing.Size(133, 131);
            this.btnMakeScreenArea.TabIndex = 2;
            this.btnMakeScreenArea.Text = "Make screenshot from area";
            this.btnMakeScreenArea.UseVisualStyleBackColor = true;
            this.btnMakeScreenArea.Click += new System.EventHandler(this.btnMakeScreenArea_Click);
            // 
            // btnCaptBackgroung
            // 
            this.btnCaptBackgroung.Location = new System.Drawing.Point(151, 149);
            this.btnCaptBackgroung.Name = "btnCaptBackgroung";
            this.btnCaptBackgroung.Size = new System.Drawing.Size(140, 131);
            this.btnCaptBackgroung.TabIndex = 3;
            this.btnCaptBackgroung.Text = "Capture background window";
            this.btnCaptBackgroung.UseVisualStyleBackColor = true;
            this.btnCaptBackgroung.Click += new System.EventHandler(this.btnCaptBackground_Click);
            // 
            // frmCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(303, 292);
            this.Controls.Add(this.btnCaptBackgroung);
            this.Controls.Add(this.btnMakeScreenArea);
            this.Controls.Add(this.btnMakeScreenClip);
            this.Controls.Add(this.btnMakeScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMakeScreen;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem tlsmExit;
        private System.Windows.Forms.NotifyIcon notifIcon;
        private System.Windows.Forms.Button btnMakeScreenClip;
        private System.Windows.Forms.Button btnMakeScreenArea;
        private System.Windows.Forms.Button btnCaptBackgroung;
        private System.Windows.Forms.ToolStripMenuItem tlsmSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

