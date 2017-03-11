namespace Encrypter
{
    partial class FrmEncrypter
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
            this.PickerIn = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtSave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOut = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.PickerOut = new System.Windows.Forms.SaveFileDialog();
            this.BtnDelAll = new System.Windows.Forms.Button();
            this.BtnDelFile = new System.Windows.Forms.Button();
            this.BtnInFile = new System.Windows.Forms.Button();
            this.LstFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PickerIn
            // 
            this.PickerIn.Multiselect = true;
            this.PickerIn.Title = "导入文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "密码：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(80, 320);
            this.TxtPassword.MaxLength = 128;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(500, 28);
            this.TxtPassword.TabIndex = 7;
            // 
            // TxtSave
            // 
            this.TxtSave.Location = new System.Drawing.Point(116, 365);
            this.TxtSave.MaxLength = 32768;
            this.TxtSave.Name = "TxtSave";
            this.TxtSave.ReadOnly = true;
            this.TxtSave.Size = new System.Drawing.Size(464, 28);
            this.TxtSave.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "保存位置：";
            // 
            // BtnOut
            // 
            this.BtnOut.AutoSize = true;
            this.BtnOut.Location = new System.Drawing.Point(589, 365);
            this.BtnOut.Name = "BtnOut";
            this.BtnOut.Size = new System.Drawing.Size(55, 28);
            this.BtnOut.TabIndex = 10;
            this.BtnOut.Text = "...";
            this.BtnOut.UseVisualStyleBackColor = true;
            this.BtnOut.Click += new System.EventHandler(this.BtnOut_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Location = new System.Drawing.Point(460, 402);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(100, 40);
            this.BtnSetting.TabIndex = 11;
            this.BtnSetting.Text = "高级加密";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Visible = false;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(566, 402);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 40);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "开始加密";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // PickerOut
            // 
            this.PickerOut.DefaultExt = "en";
            this.PickerOut.Filter = "加密文件(*.en)|*.en|All files (*.*)|*.*";
            this.PickerOut.Title = "选择保存位置";
            // 
            // BtnDelAll
            // 
            this.BtnDelAll.Location = new System.Drawing.Point(227, 258);
            this.BtnDelAll.Name = "BtnDelAll";
            this.BtnDelAll.Size = new System.Drawing.Size(100, 40);
            this.BtnDelAll.TabIndex = 16;
            this.BtnDelAll.Text = "全部移除";
            this.BtnDelAll.UseVisualStyleBackColor = true;
            this.BtnDelAll.Click += new System.EventHandler(this.BtnDelAll_Click);
            // 
            // BtnDelFile
            // 
            this.BtnDelFile.Location = new System.Drawing.Point(121, 258);
            this.BtnDelFile.Name = "BtnDelFile";
            this.BtnDelFile.Size = new System.Drawing.Size(100, 40);
            this.BtnDelFile.TabIndex = 15;
            this.BtnDelFile.Text = "移除文件";
            this.BtnDelFile.UseVisualStyleBackColor = true;
            this.BtnDelFile.Click += new System.EventHandler(this.BtnDelFile_Click);
            // 
            // BtnInFile
            // 
            this.BtnInFile.Location = new System.Drawing.Point(15, 258);
            this.BtnInFile.Name = "BtnInFile";
            this.BtnInFile.Size = new System.Drawing.Size(100, 40);
            this.BtnInFile.TabIndex = 14;
            this.BtnInFile.Text = "添加文件";
            this.BtnInFile.UseVisualStyleBackColor = true;
            this.BtnInFile.Click += new System.EventHandler(this.BtnInFile_Click);
            // 
            // LstFile
            // 
            this.LstFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LstFile.FullRowSelect = true;
            this.LstFile.GridLines = true;
            this.LstFile.HideSelection = false;
            this.LstFile.Location = new System.Drawing.Point(15, 42);
            this.LstFile.Name = "LstFile";
            this.LstFile.Size = new System.Drawing.Size(600, 200);
            this.LstFile.TabIndex = 13;
            this.LstFile.UseCompatibleStateImageBehavior = false;
            this.LstFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "完全路径";
            this.columnHeader2.Width = 350;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "选择文件";
            // 
            // FrmEncrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 464);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnDelAll);
            this.Controls.Add(this.BtnDelFile);
            this.Controls.Add(this.BtnInFile);
            this.Controls.Add(this.LstFile);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnSetting);
            this.Controls.Add(this.BtnOut);
            this.Controls.Add(this.TxtSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label1);
            this.Name = "FrmEncrypter";
            this.Text = "加密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog PickerIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnOut;
        private System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.SaveFileDialog PickerOut;
        private System.Windows.Forms.Button BtnDelAll;
        private System.Windows.Forms.Button BtnDelFile;
        private System.Windows.Forms.Button BtnInFile;
        private System.Windows.Forms.ListView LstFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
    }
}