using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace main
{
    class MD5Encrypt64
    {
        public static String MD5Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] Data = System.Text.Encoding.Default.GetBytes(password);
            byte[] md5Data = md5.ComputeHash(Data);
            md5.Clear();
            string Newpassword = "";
            for (int i = 0; i < md5Data.Length; i++)
            {
                Newpassword += md5Data[i].ToString("x").PadLeft(2, '0');
            }
            return Newpassword;
        }
    }
}
