using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmStart());
        }
        public static byte[] ConvertUIntToByteArray(uint v)//类型转换
        {
            byte[] result = new byte[4];
            result[0] = (byte)(v & 0xFF);
            result[1] = (byte)((v >> 8) & 0xFF);
            result[2] = (byte)((v >> 16) & 0xFF);
            result[3] = (byte)((v >> 24) & 0xFF);
            return result;
        }
        public static byte[] ConvertIntToByteArray(int v)//类型转换
        {
            byte[] result = new byte[4];
            result[0] = (byte)(v & 0xFF);
            result[1] = (byte)((v >> 8) & 0xFF);
            result[2] = (byte)((v >> 16) & 0xFF);
            result[3] = (byte)((v >> 24) & 0xFF);
            return result;
        }
        public static byte[] ConvertLongToByteArray(long v)//类型转换
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
        public static uint ConvertByteArrayToUInt(byte[] v, int offset)//类型转换
        {
            if (offset + 4 > v.Length) return 0;
            uint output;
            output = (uint)v[offset];
            output |= (uint)(v[offset + 1] << 8);
            output |= (uint)(v[offset + 2] << 16);
            output |= (uint)(v[offset + 3] << 24);
            return output;
        }

    }
    
}
