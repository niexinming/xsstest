using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace xsstest
{
    public class desclass
    {
        private const string KEY_64 = "J^fA5tVi";
        private const string IV_64 = "DqS6Ncr9";
         public  string EnCode(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("J^fA5tVi");
            byte[] bytes2 = Encoding.ASCII.GetBytes("DqS6Ncr9");
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            int keySize = dESCryptoServiceProvider.KeySize;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(data);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        private  string DesDecrypt(string decryptString)
        {
            byte[] keyBytes = Encoding.ASCII.GetBytes("J^fA5tVi");
            byte[] keyIV = Encoding.ASCII.GetBytes("DqS6Ncr9");
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            try {
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
            }
            catch
            {
                return null;
            }
            return Encoding.UTF8.GetString(mStream.ToArray());
        }

        public string yanzheng(string cookie,string sessinname)
        {
            mysql sql = new mysql();
            if(sessinname=="" || sessinname==null)
            {
                if(cookie=="" || cookie==null)
                {
                    return null;
                }
                else
                {
                    
                    string mycookie = DesDecrypt(cookie);
                    bool isok=sql.login(mycookie, "", 3);
                    if(isok==true)
                    {
                        return mycookie;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                bool isok = sql.login(sessinname, "", 3);
                if (isok == true)
                {
                    return sessinname;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}