using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Encrypter
{
    public partial class FrmDecrypter : Form
    {
        public FrmDecrypter()
        {
            InitializeComponent();
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            PickerOut.ShowDialog();//输出路径选择
            TxtSave.Text = PickerOut.SelectedPath;
        }

        private void FrmDecrypter_Load(object sender, EventArgs e)
        {
            
            PickerIn.FileName = "";
            PickerIn.ShowDialog();//接受文件
            if (PickerIn.FileName == "")//容错
            {
                const string ERRMSG = "错误\n指定的文件不存在！";
                MessageBox.Show(ERRMSG, "错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Close();
            }
            else
            {
                FileStream fin = File.OpenRead(PickerIn.FileName);//打开文件
                if (fin == null)//容错
                {
                    const string ERRMSG = "错误\n文件读取失误！请检查权限";
                    MessageBox.Show(ERRMSG, "错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Close();
                }
                if (chkhead(fin))//判断文件头是否符合
                {
                     make_list(fin);//更新文件列表
                }else//不符合，报错
                {
                    const string ERRMSG = "错误\n文件不合法或被损坏！";
                    MessageBox.Show(ERRMSG, "错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Close();
                }
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            string ERRMSG = "错误";//错误处理
            if (TxtPassword.Text.Length == 0)
            {
                ERRMSG += "\n请输入密码！";
            }
            if (TxtSave.Text.Length == 0)
            {
                ERRMSG += "\n请指定输出路径！";
            }
            if (ERRMSG != "错误")
            {
                MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ask = MessageBox.Show("确定开始解密吗？\n提示：解密需要耐心，请不要操作程序~", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == DialogResult.No) return;
            Visible = false;
            FrmWaitng frm = new FrmWaitng();
            frm.Show();
            FileStream fin = File.OpenRead(PickerIn.FileName);//读输入文件
            if (fin == null)
            {
                ERRMSG += "\n文件读失败，请考虑是否被其他程序占用";
                MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            chkhead(fin);//再次检验，防止之间的修改
            while (fin.Position < fin.Length)//没有读完，就一直读
            {
                FileStream fout=null;
                long len=read_file_head(fin, ref fout);//读单文件头，更新fout指针
                if (fout == null)//容错
                {
                    ERRMSG += "\n文件写失败，请考虑是否被其他程序占用";
                    MessageBox.Show(ERRMSG, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Decrypt(fin, fout, TxtPassword.Text,len);//解密单文件
                fout.Close();
            }
            frm.Close();
            Visible = true;
            MessageBox.Show("解密完成！","解密成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        public static void Decrypt(FileStream fin, FileStream fout, string key,long len)//文件解密入口
        {
            byte[] tempin = new byte[8];
            long convered_len = (len % 8 == 0 ? len : (len / 8 + 1) * 8)*4;//获得实际存储长度
            fin.Seek(convered_len, SeekOrigin.Current);
            long endlen = fin.Position;//获得密文长度
            fin.Seek(-convered_len, SeekOrigin.Current);
            while (fin.Position!=endlen)//判断是否到达单文件尾
            {
                fin.Read(tempin, 0, 8);//读
                byte[] tempout = Decrypt(tempin, Encoding.Default.GetBytes(key));//解密

                fout.Write(tempout, 0, tempout.Length);//输出
            }
            fout.SetLength(len);//截去多余空格
        }
        public static byte[] Decrypt(byte[] data, byte[] key)//通用TEA解密
        {
            uint[] formattedKey = FormatKey(key);
            int x = 0;
            uint[] tempData = new uint[2];
            byte[] dataBytes = new byte[data.Length / 8 * 2];
            for (int i = 0; i < data.Length; i += 8)
            {
                tempData[0] = ConvertByteArrayToUInt(data, i);
                tempData[1] = ConvertByteArrayToUInt(data, i + 4);
                decode(tempData, formattedKey);
                dataBytes[x++] = (byte)tempData[0];
                dataBytes[x++] = (byte)tempData[1];
            }
            //修剪添加的空字符
            if (dataBytes[dataBytes.Length - 1] == 0x0)
            {
                byte[] result = new byte[dataBytes.Length - 1];
                Array.Copy(dataBytes, 0, result, 0, dataBytes.Length - 1);
            }
            return dataBytes;

        }
        static void decode(uint[] v, uint[] k, uint delta = 0x9e3779b9, uint n = 32)//TEA核心代码
        {
            uint v0 = v[0], v1 = v[1], sum = 0xC6EF3720, i;  /* set up */
            uint k0 = k[0], k1 = k[1], k2 = k[2], k3 = k[3];   /* cache key */
            for (i = 0; i < n; i++)
            {                         /* basic cycle start */
                v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
                v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                sum -= delta;
            }                                              /* end cycle */
            v[0] = v0; v[1] = v1;
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
        private static long ConvertByteArrayToLong(byte[] v, int offset=0)//类型转换
        {
            if (offset + 4 > v.Length) return 0;
            long output;
            output = (uint)v[offset];
            output |= (uint)(v[offset + 1] << 8);
            output |= (uint)(v[offset + 2] << 16);
            output |= (uint)(v[offset + 3] << 24);
            output |= (uint)(v[offset + 4] << 32);
            output |= (uint)(v[offset + 5] << 40);
            output |= (uint)(v[offset + 6] << 48);
            output |= (uint)(v[offset + 7] << 56);
            return output;
        }
        private static uint ConvertByteArrayToUInt(byte[] v, int offset=0)//类型转换
        {
            if (offset + 4 > v.Length) return 0;
            uint output;
            output = (uint)v[offset];
            output |= (uint)(v[offset + 1] << 8);
            output |= (uint)(v[offset + 2] << 16);
            output |= (uint)(v[offset + 3] << 24);
            return output;
        }
        private static int ConvertByteArrayToInt(byte[] v, int offset = 0)//类型转换
        {
            if (offset + 4 > v.Length) return 0;
            int output;
            output = (int)v[offset];
            output |= (int)(v[offset + 1] << 8);
            output |= (int)(v[offset + 2] << 16);
            output |= (int)(v[offset + 3] << 24);
            return output;
        }
        static uint[] FormatKey(byte[] key)//将文本格式化为标准KEY
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
        bool chkhead(FileStream fin)//检验头
        {
            byte[] aa = Encoding.Default.GetBytes("1000TEA");//预期
            byte[] bb = new byte[7];
            fin.Read(bb, 0, 7);
            if (aa.Length != bb.Length) return false;//比对
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] != bb[i]) return false;
            }
            return true;
        }
        void make_list(FileStream fin)//更新文件列表
        {
            while (fin.Length > fin.Position)//没读完
            {
                byte[] tin = new byte[8];
                fin.Read(tin, 0, 8);
                long lenfile = ConvertByteArrayToLong(tin);//读文件长度
                fin.Read(tin, 0, 4);
                int lenname = ConvertByteArrayToInt(tin);
                byte[] name = new byte[lenname];//文件名
                fin.Read(name, 0, lenname);
                string s = System.Text.Encoding.Default.GetString(name);
                LstFile1.Items.Add(s);//更新列表
                long convered_len = (lenfile % 8 == 0 ? lenfile : (lenfile / 8 + 1) * 8) * 4;//转换为实际存储长度
                fin.Seek(convered_len, SeekOrigin.Current);//跳转下一文件
            }
        }
        long read_file_head(FileStream fin, ref FileStream fout)//读文件头，返回fout
        {
            byte[] tin = new byte[8];
            fin.Read(tin, 0, 8);
            long lenfile = ConvertByteArrayToLong(tin);
            fin.Read(tin, 0, 4);
            int lenname = ConvertByteArrayToInt(tin);
            byte[] name = new byte[lenname];
            fin.Read(name, 0, lenname);
            string s = System.Text.Encoding.Default.GetString(name);
            fout = File.Create(Path.Combine(TxtSave.Text, s));
            return lenfile;//返回的是实际长度，不是加密后长度
        }

    }
}
