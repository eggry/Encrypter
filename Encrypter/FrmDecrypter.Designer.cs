namespace Encrypter
{
    partial class FrmDecrypter
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
            this.LstFile1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.LstFile2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSave = new System.Windows.Forms.TextBox();
            this.BtnOut = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.PickerOut = new System.Windows.Forms.FolderBrowserDialog();
            this.PickerIn = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LstFile1
            // 
            this.LstFile1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LstFile1.FullRowSelect = true;
            this.LstFile1.GridLines = true;
            this.LstFile1.HideSelection = false;
            this.LstFile1.Location = new System.Drawing.Point(12, 12);
            this.LstFile1.Name = "LstFile1";
            this.LstFile1.Size = new System.Drawing.Size(606, 200);
            this.LstFile1.TabIndex = 14;
            this.LstFile1.UseCompatibleStateImageBehavior = false;
            this.LstFile1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "可选文件";
            this.columnHeader1.Width = 300;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 40);
            this.button1.TabIndex = 15;
            this.button1.Text = "将所选加入解密队列";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // LstFile2
            // 
            this.LstFile2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.LstFile2.FullRowSelect = true;
            this.LstFile2.GridLines = true;
            this.LstFile2.HideSelection = false;
            this.LstFile2.Location = new System.Drawing.Point(318, 12);
            this.LstFile2.Name = "LstFile2";
            this.LstFile2.Size = new System.Drawing.Size(300, 200);
            this.LstFile2.TabIndex = 14;
            this.LstFile2.UseCompatibleStateImageBehavior = false;
            this.LstFile2.View = System.Windows.Forms.View.Details;
            this.LstFile2.Visible = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "解密队列";
            this.columnHeader2.Width = 300;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 40);
            this.button2.TabIndex = 15;
            this.button2.Text = "将所选移除解密队列";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "密码：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(80, 288);
            this.TxtPassword.MaxLength = 128;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(500, 28);
            this.TxtPassword.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "保存位置：";
            // 
            // TxtSave
            // 
            this.TxtSave.Location = new System.Drawing.Point(116, 334);
            this.TxtSave.Name = "TxtSave";
            this.TxtSave.ReadOnly = true;
            this.TxtSave.Size = new System.Drawing.Size(464, 28);
            this.TxtSave.TabIndex = 18;
            // 
            // BtnOut
            // 
            this.BtnOut.AutoSize = true;
            this.BtnOut.Location = new System.Drawing.Point(599, 334);
            this.BtnOut.Name = "BtnOut";
            this.BtnOut.Size = new System.Drawing.Size(55, 28);
            this.BtnOut.TabIndex = 19;
            this.BtnOut.Text = "...";
            this.BtnOut.UseVisualStyleBackColor = true;
            this.BtnOut.Click += new System.EventHandler(this.BtnOut_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(566, 392);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 40);
            this.BtnStart.TabIndex = 21;
            this.BtnStart.Text = "开始解密";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Location = new System.Drawing.Point(460, 392);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(100, 40);
            this.BtnSetting.TabIndex = 20;
            this.BtnSetting.Text = "高级设置";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Visible = false;
            // 
            // PickerIn
            // 
            this.PickerIn.FileName = "openFileDialog1";
            this.PickerIn.Filter = "加密文件(*.en)|*.en|All files (*.*)|*.*";
            // 
            // FrmDecrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 444);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnSetting);
            this.Controls.Add(this.BtnOut);
            this.Controls.Add(this.TxtSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LstFile2);
            this.Controls.Add(this.LstFile1);
            this.Name = "FrmDecrypter";
            this.Text = "FrmDecrypter";
            this.Load += new System.EventHandler(this.FrmDecrypter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LstFile1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView LstFile2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSave;
        private System.Windows.Forms.Button BtnOut;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.FolderBrowserDialog PickerOut;
        private System.Windows.Forms.OpenFileDialog PickerIn;
    }
}