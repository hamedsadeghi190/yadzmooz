
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Tools.General
{
    public class DES
    {
        public static string Decrypt(string cipherString, string Password)
        {
                byte[] buffer = Convert.FromBase64String(Password);
                byte[] inputBuffer = Convert.FromBase64String(cipherString);
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7

                };
                ICryptoTransform transform = provider2.CreateDecryptor();
                if (inputBuffer.Length > 0)
                {
                    byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                    provider2.Clear();
                    return Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    //Error = Messages.ReturnValue("inputBuffer.Length > 0", true);
                    return "NikoError";
                }            
        }
        public static string Decrypt(byte[] inputBuffer, string Password)
        {
                byte[] buffer = Convert.FromBase64String(Password);
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7

                };
                ICryptoTransform transform = provider2.CreateDecryptor();
                if (inputBuffer.Length > 0)
                {
                    byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                    provider2.Clear();
                    return Encoding.UTF8.GetString(bytes);
                }
                else
                    return "";
            
        }
        public static string Encrypt(string toEncrypt, string Password)
        {
                        //AArIFHhOAi2fqmA/FCr6TtQKYgFO5je+
                byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] buffer = Convert.FromBase64String(Password);
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                provider2.Clear();
                return Convert.ToBase64String(inArray, 0, inArray.Length);            
        }
        public static byte[] EncryptGetBytes(string toEncrypt, string Password)
        {
                byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] buffer = Convert.FromBase64String(Password);
                //AppSettingsReader reader = new AppSettingsReader();
                //MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
                //byte[] buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(Password));
                //provider.Clear();
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                provider2.Clear();
                return inArray;            
        }
        //public static string Encrypt(byte[] bytes, string Password, out string Error)
        //{
        //    try
        //    {
        //        AppSettingsReader reader = new AppSettingsReader();
        //        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        //        byte[] buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(Password));
        //        provider.Clear();
        //        TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
        //        {
        //            Key = buffer,
        //            Mode = CipherMode.ECB,
        //            Padding = PaddingMode.PKCS7
        //        };
        //        byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        //        provider2.Clear();
        //        Error = "";
        //        return Convert.ToBase64String(inArray, 0, inArray.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Error = Messages.ReturnValue(ex.Message, true);
        //        return "";
        //    }

        //}
    }
}
