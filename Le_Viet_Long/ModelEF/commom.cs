using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
   public class commom
    {
        public static string EncryptMD5(string md5)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(md5);
            System.Security.Cryptography.MD5CryptoServiceProvider mmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashByte = mmd5.ComputeHash(bytes);
            string hashtring = "";
            for (int i = 0; i < hashByte.Length; i++)
            {
                hashtring += Convert.ToString(hashByte[i], 16).PadLeft(2, '0');

            }
            return hashtring.PadLeft(32, '0');
        }
    }
}
