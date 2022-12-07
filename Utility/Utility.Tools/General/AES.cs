//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace Utility.Tools.General
//{
//    public class AES
//    {
//        public static string Encrypt(string Key,string strPlainText)
//        {
//            var myRijndael = GetKey(Key);
//            byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
//            ICryptoTransform transform = myRijndael.CreateEncryptor();
//            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);
//            return Convert.ToBase64String(cipherText);
//        }
//        public static string Decrypt(string Key, string encryptedText)
//        {
//            var myRijndael = GetKey(Key);
//            var encryptedBytes = Convert.FromBase64String(encryptedText);
//            ICryptoTransform transform = myRijndael.CreateDecryptor();
//            byte[] cipherText = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
//            return System.Text.Encoding.UTF8.GetString(cipherText);
//        }
//        private static RijndaelManaged GetKey(string strPassword)
//        {
//            var iterations = 1000;
//            var salt = System.Text.Encoding.UTF8.GetBytes("cryptography123example");
//            return new RijndaelManaged 
//            {
//                BlockSize = 128,
//                KeySize = 128,
//                IV = HexStringToByteArray("a5f8d2e9c1721ae0e84ad660c472d1f3"),
//                Padding = PaddingMode.PKCS7,
//                Mode = CipherMode.CBC,                                
//                Key = GenerateKey(strPassword,iterations,salt),
//            };
//    }
//        private static byte[] HexStringToByteArray(string strHex)
//        {
//            dynamic r = new byte[strHex.Length / 2];
//            for (int i = 0; i <= strHex.Length - 1; i += 2)
//            {
//                r[i / 2] = Convert.ToByte(Convert.ToInt32(strHex.Substring(i, 2), 16));
//            }
//            return r;
//        }
//        private static byte[] GenerateKey(string strPassword, int iterations, byte[] salt)
//        {
//            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(System.Text.Encoding.UTF8.GetBytes(strPassword), salt, iterations);
//            return rfc2898.GetBytes(128 / 8);
//        }
//    }
//}
