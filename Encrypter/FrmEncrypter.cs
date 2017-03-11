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
            PickerIn.FileName="";
            PickerIn.ShowDialog();//接受文件
            const string ERRMSG1 = "以下文件：\n",ERRMSG3="无法加入。\n列表中已存在同名文件！";
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
                        if(lvi1.Text==lvi.Text)
                        {
                            ERRMSG2 += lvi.Text+"(" + filename + ")\n";
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
                MessageBox.Show(ERRMSG1 + ERRMSG2 + ERRMSG3, "错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
        private void make_head(FileStream fout)//写文件头
        {
            const string VER = "1000";
            const string ALGO = "TEA";
            Byte[] info = Encoding.Default.GetBytes(VER+ALGO);
            fout.Write(info, 0, info.Length);//写头
        }
        private void make_file_head(FileStream fin, FileStream fout)//写单文件头
        {
            fout.Write(ConvertLongToByteArray(fin.Length),0,8);//文件大小
            Byte[] name = Encoding.Default.GetBytes(System.IO.Path.GetFileName(fin.Name));//获得文件名
            fout.Write(ConvertIntToByteArray(name.Length), 0, 4);//写文件名长度
            fout.Write(name, 0, name.Length);//写文件名
        }
        private static byte[] ConvertUIntToByteArray(uint v)//类型转换
        {
            byte[] result = new byte[4];
            result[0] = (byte)(v & 0xFF);
            result[1] = (byte)((v >> 8) & 0xFF);
            result[2] = (byte)((v >> 16) & 0xFF);
            result[3] = (byte)((v >> 24) & 0xFF);
            return result;
        }
        private static byte[] ConvertIntToByteArray(int v)//类型转换
        {
            byte[] result = new byte[4];
            result[0] = (byte)(v & 0xFF);
            result[1] = (byte)((v >> 8) & 0xFF);
            result[2] = (byte)((v >> 16) & 0xFF);
            result[3] = (byte)((v >> 24) & 0xFF);
            return result;
        }
        private static byte[] ConvertLongToByteArray(long v)//类型转换
        {
            byte[] result = new byte[8];
            result[0] = (byte)(v & 0xFF);
            result[1] = (byte)((v >> 8) & 0xFF);
            result[2] = (byte)((v >> 16) & 0xFF);
            result[3] = (byte)((v >> 24) & 0xFF);
            result[4] = (byte)((v >> 32) & 0xFF);
            result[5] = (byte)((v >> 40) & 0xFF);
            result[6] = (byte)((v >> 48) & 0xFF);
            result[7] = (byte)((v >> 56) & 0xFF);
            return result;
        }
        private static uint ConvertByteArrayToUInt(byte[] v, int offset)//类型转换
        {
            if (offset + 4 > v.Length) return 0;
            uint output;
            output = (uint)v[offset];
            output |= (uint)(v[offset + 1] << 8);
            output |= (uint)(v[offset + 2] << 16);
            output |= (uint)(v[offset + 3] << 24);
            return output;
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
                formattedKey[j++] = ConvertByteArrayToUInt(refineKey, i);
            return formattedKey;
        }
        public static void Encrypt(FileStream fin,FileStream fout,string key)//重载加密入口
        {
            byte[] tempin = new byte[8];
            while (fin.Read(tempin, 0, 8) > 0)//一直读
            {
                byte[] tempout = Encrypt(tempin, Encoding.Default.GetBytes(key));//加密
                fout.Write(tempout, 0, tempout.Length);//输出
            }
        }
        public static byte[] Encrypt(byte[] data, byte[] key)//标准化的加密
        {

            byte[] dataBytes;
            if (data.Length % 2 == 0)
            {
                dataBytes = data;

            }
            else
            {
                dataBytes = new byte[data.Length + 1];
                Array.Copy(data, 0, dataBytes, 0, data.Length);
                dataBytes[data.Length] = 0x0;

            }
            byte[] result = new byte[dataBytes.Length * 4];
            uint[] formattedKey = FormatKey(key);
            uint[] tempData = new uint[2];
            for (int i = 0; i < dataBytes.Length; i += 2)
            {
                tempData[0] = dataBytes[i];
                tempData[1] = dataBytes[i + 1];
                code(tempData, formattedKey);
                Array.Copy(ConvertUIntToByteArray(tempData[0]), 0, result, i * 4, 4);
                Array.Copy(ConvertUIntToByteArray(tempData[1]), 0, result, i * 4 + 4, 4);
            }
            return result;
        }

        #region Tea Algorithm
        static void code(uint[] v, uint[] k, uint delta = 0x9e3779b9, uint n = 32)//TEA算法核心
        {
            uint v0 = v[0], v1 = v[1], sum = 0, i;           /* set up */
            uint k0 = k[0], k1 = k[1], k2 = k[2], k3 = k[3];   /* cache key */
            for (i = 0; i < n; i++)
            {                       /* basic cycle start */
                sum += delta;
                v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            }                                              /* end cycle */
            v[0] = v0; v[1] = v1;
        }

        
        #endregion
    
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
            var ask=MessageBox.Show("确定开始加密吗？\n提示：加密需要耐心，请不要操作程序~", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                FileStream fin=File.OpenRead(lvi.SubItems[1].Text);//遍历列表，加密
                if (fin == null)
                {
                    ERRMSG += "\n文件读失败，请考虑是否被其他程序占用";
                    MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                make_file_head(fin, fout);//制作单文件头
                Encrypt(fin, fout,TxtPassword.Text);//加密并写入
                fin.Close();//关
            }
            fout.Close();//关
            frm.Close();
            Visible = true;
            MessageBox.Show("加密完成！","加密成功",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
