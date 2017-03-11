namespace Encrypter
{
    partial class FrmStart
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
            this.BtnEncrypter = new System.Windows.Forms.Button();
            this.BtnDecrypter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEncrypter
            // 
            this.BtnEncrypter.Location = new System.Drawing.Point(15, 116);
            this.BtnEncrypter.Name = "BtnEncrypter";
            this.BtnEncrypter.Size = new System.Drawing.Size(175, 50);
            this.BtnEncrypter.TabIndex = 0;
            this.BtnEncrypter.Text = "加密文件";
            this.BtnEncrypter.UseVisualStyleBackColor = true;
            this.BtnEncrypter.Click += new System.EventHandler(this.BtnEncrypter_Click);
            // 
            // BtnDecrypter
            // 
            this.BtnDecrypter.Location = new System.Drawing.Point(15, 192);
            this.BtnDecrypter.Name = "BtnDecrypter";
            this.BtnDecrypter.Size = new System.Drawing.Size(175, 50);
            this.BtnDecrypter.TabIndex = 1;
            this.BtnDecrypter.Text = "解密文件";
            this.BtnDecrypter.UseVisualStyleBackColor = true;
            this.BtnDecrypter.Click += new System.EventHandler(this.BtnDecrypter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "欢迎使用！\r\n程序采用TEA加密算法，对您的数据进行全方位保护。\r\n请问客官您要干些什么？";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnAbout
            // 
            this.BtnAbout.Location = new System.Drawing.Point(231, 116);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(175, 50);
            this.BtnAbout.TabIndex = 3;
            this.BtnAbout.Text = "软件信息";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 276);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDecrypter);
            this.Controls.Add(this.BtnEncrypter);
            this.Name = "FrmStart";
            this.Text = "多文件加解密程序【By:Eggry】";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEncrypter;
        private System.Windows.Forms.Button BtnDecrypter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAbout;
    }
}