namespace ScreenShoter.Forms
{
    partial class frmSettings
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbKeyGlobalScr = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetKeyGlobalScr = new System.Windows.Forms.Button();
            this.chbUseCtrlGlobalScr = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFileNameLength = new System.Windows.Forms.NumericUpDown();
            this.btnSetKeyAreaScr = new System.Windows.Forms.Button();
            this.chbUseCtrlAreaScr = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbKeyAreaScr = new System.Windows.Forms.TextBox();
            this.btnSetKeyClipboardScr = new System.Windows.Forms.Button();
            this.chbUseCtrlClipboardScr = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbKeyClipboardScr = new System.Windows.Forms.TextBox();
            this.btnSetKeyBackgroundScr = new System.Windows.Forms.Button();
            this.chbUseCtrlBackgroundScr = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbKeyBackgroundScr = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileNameLength)).BeginInit();
            this.SuspendLayout();
            // 
            // txbPath
            // 
            this.txbPath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txbPath.Location = new System.Drawing.Point(198, 12);
            this.txbPath.Name = "txbPath";
            this.txbPath.ReadOnly = true;
            this.txbPath.Size = new System.Drawing.Size(274, 20);
            this.txbPath.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectPath.Image")));
            this.btnSelectPath.Location = new System.Drawing.Point(181, 11);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(21, 21);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Папка для сохранения файлов";
            // 
            // txbKeyGlobalScr
            // 
            this.txbKeyGlobalScr.Location = new System.Drawing.Point(183, 19);
            this.txbKeyGlobalScr.Name = "txbKeyGlobalScr";
            this.txbKeyGlobalScr.ReadOnly = true;
            this.txbKeyGlobalScr.Size = new System.Drawing.Size(268, 20);
            this.txbKeyGlobalScr.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetKeyBackgroundScr);
            this.groupBox1.Controls.Add(this.chbUseCtrlBackgroundScr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbKeyBackgroundScr);
            this.groupBox1.Controls.Add(this.btnSetKeyClipboardScr);
            this.groupBox1.Controls.Add(this.chbUseCtrlClipboardScr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbKeyClipboardScr);
            this.groupBox1.Controls.Add(this.btnSetKeyAreaScr);
            this.groupBox1.Controls.Add(this.chbUseCtrlAreaScr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbKeyAreaScr);
            this.groupBox1.Controls.Add(this.btnSetKeyGlobalScr);
            this.groupBox1.Controls.Add(this.chbUseCtrlGlobalScr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbKeyGlobalScr);
            this.groupBox1.Location = new System.Drawing.Point(15, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 223);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сочетания клавиш";
            // 
            // btnSetKeyGlobalScr
            // 
            this.btnSetKeyGlobalScr.Location = new System.Drawing.Point(102, 17);
            this.btnSetKeyGlobalScr.Name = "btnSetKeyGlobalScr";
            this.btnSetKeyGlobalScr.Size = new System.Drawing.Size(75, 23);
            this.btnSetKeyGlobalScr.TabIndex = 6;
            this.btnSetKeyGlobalScr.Text = "Назначить";
            this.btnSetKeyGlobalScr.UseVisualStyleBackColor = true;
            this.btnSetKeyGlobalScr.Click += new System.EventHandler(this.btnSetKeyGlobalScr_Click);
            this.btnSetKeyGlobalScr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSetKeyGlobalScr_KeyPress);
            // 
            // chbUseCtrlGlobalScr
            // 
            this.chbUseCtrlGlobalScr.AutoSize = true;
            this.chbUseCtrlGlobalScr.Location = new System.Drawing.Point(183, 45);
            this.chbUseCtrlGlobalScr.Name = "chbUseCtrlGlobalScr";
            this.chbUseCtrlGlobalScr.Size = new System.Drawing.Size(117, 17);
            this.chbUseCtrlGlobalScr.TabIndex = 5;
            this.chbUseCtrlGlobalScr.Text = "Использовать Ctrl";
            this.chbUseCtrlGlobalScr.UseVisualStyleBackColor = true;
            this.chbUseCtrlGlobalScr.CheckedChanged += new System.EventHandler(this.chbUseCtrlGlobalScr_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Весь экран";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudFileNameLength);
            this.groupBox2.Location = new System.Drawing.Point(15, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 187);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дополнительно";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Длина имени файла";
            // 
            // nudFileNameLength
            // 
            this.nudFileNameLength.Location = new System.Drawing.Point(183, 19);
            this.nudFileNameLength.Name = "nudFileNameLength";
            this.nudFileNameLength.Size = new System.Drawing.Size(120, 20);
            this.nudFileNameLength.TabIndex = 1;
            this.nudFileNameLength.ValueChanged += new System.EventHandler(this.nudFileNameLength_ValueChanged);
            // 
            // btnSetKeyAreaScr
            // 
            this.btnSetKeyAreaScr.Location = new System.Drawing.Point(102, 66);
            this.btnSetKeyAreaScr.Name = "btnSetKeyAreaScr";
            this.btnSetKeyAreaScr.Size = new System.Drawing.Size(75, 23);
            this.btnSetKeyAreaScr.TabIndex = 10;
            this.btnSetKeyAreaScr.Text = "Назначить";
            this.btnSetKeyAreaScr.UseVisualStyleBackColor = true;
            this.btnSetKeyAreaScr.Click += new System.EventHandler(this.btnSetKeyAreaScr_Click);
            this.btnSetKeyAreaScr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSetKeyAreaScr_KeyPress);
            // 
            // chbUseCtrlAreaScr
            // 
            this.chbUseCtrlAreaScr.AutoSize = true;
            this.chbUseCtrlAreaScr.Location = new System.Drawing.Point(183, 94);
            this.chbUseCtrlAreaScr.Name = "chbUseCtrlAreaScr";
            this.chbUseCtrlAreaScr.Size = new System.Drawing.Size(117, 17);
            this.chbUseCtrlAreaScr.TabIndex = 9;
            this.chbUseCtrlAreaScr.Text = "Использовать Ctrl";
            this.chbUseCtrlAreaScr.UseVisualStyleBackColor = true;
            this.chbUseCtrlAreaScr.CheckedChanged += new System.EventHandler(this.chbUseCtrlAreaScr_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Область экрана";
            // 
            // txbKeyAreaScr
            // 
            this.txbKeyAreaScr.Location = new System.Drawing.Point(183, 68);
            this.txbKeyAreaScr.Name = "txbKeyAreaScr";
            this.txbKeyAreaScr.ReadOnly = true;
            this.txbKeyAreaScr.Size = new System.Drawing.Size(268, 20);
            this.txbKeyAreaScr.TabIndex = 7;
            // 
            // btnSetKeyClipboardScr
            // 
            this.btnSetKeyClipboardScr.Location = new System.Drawing.Point(102, 120);
            this.btnSetKeyClipboardScr.Name = "btnSetKeyClipboardScr";
            this.btnSetKeyClipboardScr.Size = new System.Drawing.Size(75, 23);
            this.btnSetKeyClipboardScr.TabIndex = 14;
            this.btnSetKeyClipboardScr.Text = "Назначить";
            this.btnSetKeyClipboardScr.UseVisualStyleBackColor = true;
            this.btnSetKeyClipboardScr.Click += new System.EventHandler(this.btnSetKeyClipboardScr_Click);
            this.btnSetKeyClipboardScr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSetKeyClipboardScr_KeyPress);
            // 
            // chbUseCtrlClipboardScr
            // 
            this.chbUseCtrlClipboardScr.AutoSize = true;
            this.chbUseCtrlClipboardScr.Location = new System.Drawing.Point(183, 148);
            this.chbUseCtrlClipboardScr.Name = "chbUseCtrlClipboardScr";
            this.chbUseCtrlClipboardScr.Size = new System.Drawing.Size(117, 17);
            this.chbUseCtrlClipboardScr.TabIndex = 13;
            this.chbUseCtrlClipboardScr.Text = "Использовать Ctrl";
            this.chbUseCtrlClipboardScr.UseVisualStyleBackColor = true;
            this.chbUseCtrlClipboardScr.CheckedChanged += new System.EventHandler(this.chbUseCtrlClipboardScr_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Буфер обмена";
            // 
            // txbKeyClipboardScr
            // 
            this.txbKeyClipboardScr.Location = new System.Drawing.Point(183, 122);
            this.txbKeyClipboardScr.Name = "txbKeyClipboardScr";
            this.txbKeyClipboardScr.ReadOnly = true;
            this.txbKeyClipboardScr.Size = new System.Drawing.Size(268, 20);
            this.txbKeyClipboardScr.TabIndex = 11;
            // 
            // btnSetKeyBackgroundScr
            // 
            this.btnSetKeyBackgroundScr.Location = new System.Drawing.Point(102, 170);
            this.btnSetKeyBackgroundScr.Name = "btnSetKeyBackgroundScr";
            this.btnSetKeyBackgroundScr.Size = new System.Drawing.Size(75, 23);
            this.btnSetKeyBackgroundScr.TabIndex = 18;
            this.btnSetKeyBackgroundScr.Text = "Назначить";
            this.btnSetKeyBackgroundScr.UseVisualStyleBackColor = true;
            this.btnSetKeyBackgroundScr.Click += new System.EventHandler(this.btnSetKeyBackgroundScr_Click);
            this.btnSetKeyBackgroundScr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSetKeyBackgroundScr_KeyPress);
            // 
            // chbUseCtrlBackgroundScr
            // 
            this.chbUseCtrlBackgroundScr.AutoSize = true;
            this.chbUseCtrlBackgroundScr.Location = new System.Drawing.Point(183, 198);
            this.chbUseCtrlBackgroundScr.Name = "chbUseCtrlBackgroundScr";
            this.chbUseCtrlBackgroundScr.Size = new System.Drawing.Size(117, 17);
            this.chbUseCtrlBackgroundScr.TabIndex = 17;
            this.chbUseCtrlBackgroundScr.Text = "Использовать Ctrl";
            this.chbUseCtrlBackgroundScr.UseVisualStyleBackColor = true;
            this.chbUseCtrlBackgroundScr.CheckedChanged += new System.EventHandler(this.chbUseCtrlBackgroundScr_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Окно";
            // 
            // txbKeyBackgroundScr
            // 
            this.txbKeyBackgroundScr.Location = new System.Drawing.Point(183, 172);
            this.txbKeyBackgroundScr.Name = "txbKeyBackgroundScr";
            this.txbKeyBackgroundScr.ReadOnly = true;
            this.txbKeyBackgroundScr.Size = new System.Drawing.Size(268, 20);
            this.txbKeyBackgroundScr.TabIndex = 15;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txbPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileNameLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbKeyGlobalScr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetKeyGlobalScr;
        private System.Windows.Forms.CheckBox chbUseCtrlGlobalScr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudFileNameLength;
        private System.Windows.Forms.Button btnSetKeyBackgroundScr;
        private System.Windows.Forms.CheckBox chbUseCtrlBackgroundScr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbKeyBackgroundScr;
        private System.Windows.Forms.Button btnSetKeyClipboardScr;
        private System.Windows.Forms.CheckBox chbUseCtrlClipboardScr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbKeyClipboardScr;
        private System.Windows.Forms.Button btnSetKeyAreaScr;
        private System.Windows.Forms.CheckBox chbUseCtrlAreaScr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbKeyAreaScr;
    }
}