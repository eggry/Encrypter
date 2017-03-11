using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypter
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }

        private void BtnEncrypter_Click(object sender, EventArgs e)
        {
            Visible = false;
            new FrmEncrypter().ShowDialog();
            Visible = true;
        }

        private void BtnDecrypter_Click(object sender, EventArgs e)
        {
            Visible = false;
            new FrmDecrypter().ShowDialog();
            Visible = true;
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            Visible = false;
            new FrmAbout().ShowDialog();
            Visible = true;
        }
    }
}
