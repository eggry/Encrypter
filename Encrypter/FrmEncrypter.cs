using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Encrypter
{
    public partial class FrmEncrypter : Form
    {
        public FrmEncrypter()
        {
            InitializeComponent();
        }
        private void BtnDelFile_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LstFile.SelectedItems)//清空所选项
            {
                LstFile.Items.Remove(lvi);
            }
        }
        private void BtnInFile_Click(object sender, EventArgs e)//加文件
        {
            PickerIn.FileName = "";
            PickerIn.ShowDialog();//接受文件
            const string ERRMSG1 = "以下文件：\n", ERRMSG3 = "无法加入。\n列表中已存在同名文件！";
            string ERRMSG2 = "";
            if (PickerIn.FileName != "")
            {
                LstFile.BeginUpdate();
                foreach (string filename in PickerIn.FileNames)//遍历，找是否重复
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = System.IO.Path.GetFileName(filename);
                    lvi.SubItems.Add(filename);
                    foreach (ListViewItem lvi1 in LstFile.Items)
                    {
                        if (lvi1.Text == lvi.Text)
                        {
                            ERRMSG2 += lvi.Text + "(" + filename + ")\n";
                            goto aout;
                        }//有的话输出错误信息
                    }
                    LstFile.Items.Add(lvi);
                    aout:
                    ;
                }
                LstFile.EndUpdate();
            }
            if (ERRMSG2 != "")//错误信息
            {
                MessageBox.Show(ERRMSG1 + ERRMSG2 + ERRMSG3, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnDelAll_Click(object sender, EventArgs e)//清空列表
        {
            LstFile.Items.Clear();
        }
        private void BtnOut_Click(object sender, EventArgs e)//选择输出路径
        {
            PickerOut.ShowDialog();
            TxtSave.Text = PickerOut.FileName;
        }
        private void BtnSetting_Click(object sender, EventArgs e)//TODO，暂时隐藏
        {
            new FrmSettings().ShowDialog();
            Visible = false;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //容错
            string ERRMSG = "错误";
            if (TxtPassword.Text.Length == 0)
            {
                ERRMSG += "\n请输入密码！";
            }
            if (TxtSave.Text.Length == 0)
            {
                ERRMSG += "\n请指定输出路径！";
            }
            if (LstFile.Items.Count <= 0)
            {
                ERRMSG += "\n请添加加密文件！";
            }
            if (ERRMSG != "错误")
            {
                MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //读取文件
            var ask = MessageBox.Show("确定开始加密吗？\n提示：加密需要耐心，请不要操作程序~", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == DialogResult.No) return;
            Visible = false;
            FrmWaitng frm = new FrmWaitng();
            frm.Show();
            FileStream fout = File.Create(TxtSave.Text);
            if (fout == null)
            {
                ERRMSG += "\n文件写失败，请考虑是否被其他程序占用";
                MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            make_head(fout); //写文件头
            foreach (ListViewItem lvi in LstFile.Items)
            {
                FileStream fin = File.OpenRead(lvi.SubItems[1].Text);//遍历列表，加密
                if (fin == null)
                {
                    ERRMSG += "\n文件读失败，请考虑是否被其他程序占用";
                    MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                make_file_head(fin, fout);//制作单文件头
                Encrypt(fin, fout, TxtPassword.Text);//加密并写入
                fin.Close();//关
            }
            fout.Close();//关
            frm.Close();
            Visible = true;
            MessageBox.Show("加密完成！", "加密成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void make_head(FileStream fout)//写文件头
        {
            const string VER = "1000";
            const string ALGO = "TEA";
            Byte[] info = Encoding.Default.GetBytes(VER + ALGO);
            fout.Write(info, 0, info.Length);//写头
        }
        private void make_file_head(FileStream fin, FileStream fout)//写单文件头
        {
            fout.Write(Encrypter.Program.ConvertLongToByteArray(fin.Length), 0, 8);//文件大小
            Byte[] name = Encoding.Default.GetBytes(System.IO.Path.GetFileName(fin.Name));//获得文件名
            fout.Write(Encrypter.Program.ConvertIntToByteArray(name.Length), 0, 4);//写文件名长度
            fout.Write(name, 0, name.Length);//写文件名
        }
        
        static uint[] FormatKey(byte[] key)//将文本转为标准KEY
        {
            byte[] refineKey = new byte[16];
            if (key.Length < 16)
            {
                Array.Copy(key, 0, refineKey, 0, key.Length);
                for (int k = key.Length; k < 16; k++)
                {
                    refineKey[k] = 0x20;
                }
            }
            else
            {
                Array.Copy(key, 0, refineKey, 0, 16);
            }
            uint[] formattedKey = new uint[4];
            int j = 0;
            for (int i = 0; i < refineKey.Length; i += 4)
               
                formattedKey[j++] = Encrypter.Program.ConvertByteArrayToUInt(refineKey, i);
            return formattedKey;
        }
        public static void Encrypt(FileStream fin, FileStream fout, string key)//重载加密入口
        {
            byte[] tempin = new byte[8];
            while (fin.Read(tempin, 0, 8) > 0)//一直读
            {
                byte[] tempout = Encrypt(tempin, Encoding.Default.GetBytes(key));//加密
                fout.Write(tempout, 0, tempout.Length);//输出
            }
        }

        public static byte[] Encrypt(byte[] data, byte[] key)//将data中的所有数据加密，返回最终结果
        {
            if (data.Length == 0) return null;
            byte[] ret;
            byte[] formatted_data;
                formatted_data = new byte[(data.Length / 8 + 1) * 8];
                data.CopyTo(formatted_data, 0);
                formatted_data[formatted_data.Length - 1] =(byte) (8 - (formatted_data.Length - data.Length));
            for (int i= 2;i>= formatted_data[formatted_data.Length - 1]; i--)
            {
                formatted_data[formatted_data.Length - i] = 0;
            }


            byte[] result = new byte[dataBytes.Length * 4];
            uint[] formattedKey = FormatKey(key);
            uint[] tempData = new uint[2];
            for (int i = 0; i < dataBytes.Length; i += 2)
            {
                tempData[0] = dataBytes[i];
                tempData[1] = dataBytes[i + 1];
                code(tempData, formattedKey);
                Array.Copy(Encrypter.Program.ConvertUIntToByteArray(tempData[0]), 0, result, i * 4, 4);
                Array.Copy(Encrypter.Program.ConvertUIntToByteArray(tempData[1]), 0, result, i * 4 + 4, 4);
            }
            return result;
        }

        void TEAencipher(uint[] v, uint[] key,uint num_rounds=64,uint delta=0x9E3779B9)
        {
            uint v0 = v[0], v1 = v[1], sum = 0;
            for (uint i = 0; i < num_rounds; i++)
            {
                v0 += (((v1 << 4) ^ (v1 >> 5)) + v1) ^ (sum + key[sum & 3]);
                sum += delta;
                v1 += (((v0 << 4) ^ (v0 >> 5)) + v0) ^ (sum + key[(sum >> 11) & 3]);
            }
            v[0] = v0; v[1] = v1;
        }

        


    }
}
