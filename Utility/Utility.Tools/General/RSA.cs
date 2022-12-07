using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Collections;
using System.Security.Cryptography;

/*https://www.codeproject.com/Articles/6623/Porting-Java-Public-Key-Hash-to-C-NET*/
namespace Utility.Tools.General
{
    public static class RSA
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Main
        public static int KeySize = 2048;
        public static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(KeySize);
        private static RSAEncryptionPadding Padding = RSAEncryptionPadding.Pkcs1;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void ImportXMLKey(string XMLKey)
        {            
                rsa = new RSACryptoServiceProvider(KeySize);
                //rsa.FromXmlString(XMLKey);
                FromXmlString(rsa,XMLKey);            
        }
        public static string AutoGenerate()
        {
            
                rsa = new RSACryptoServiceProvider(KeySize);
                //string xmlKey = rsa.ToXmlString(true);
                string xmlKey = ToXmlString(rsa,true);
                return (xmlKey);            
        }

        public static string ToXmlString(RSACryptoServiceProvider rsa, bool includePrivateParameters = false)
        {
            RSAParameters parameters = rsa.ExportParameters(includePrivateParameters);

            if (includePrivateParameters)
            {
                return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                    Convert.ToBase64String(parameters.Modulus),
                    Convert.ToBase64String(parameters.Exponent),
                    Convert.ToBase64String(parameters.P),
                    Convert.ToBase64String(parameters.Q),
                    Convert.ToBase64String(parameters.DP),
                    Convert.ToBase64String(parameters.DQ),
                    Convert.ToBase64String(parameters.InverseQ),
                    Convert.ToBase64String(parameters.D));
            }

            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(parameters.Modulus),
                Convert.ToBase64String(parameters.Exponent));
        }

        public static string FromXmlString(RSACryptoServiceProvider rsa, string XMLKey)
        {
            RSAParameters parameters = new RSAParameters();

            XMLKey = XMLKey.Substring(XMLKey.IndexOf("<RSAKeyValue>"));

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLKey);

            if (xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Modulus": parameters.Modulus = Convert.FromBase64String(node.InnerText); break;
                        case "Exponent": parameters.Exponent = Convert.FromBase64String(node.InnerText); break;
                        case "P": parameters.P = Convert.FromBase64String(node.InnerText); break;
                        case "Q": parameters.Q = Convert.FromBase64String(node.InnerText); break;
                        case "DP": parameters.DP = Convert.FromBase64String(node.InnerText); break;
                        case "DQ": parameters.DQ = Convert.FromBase64String(node.InnerText); break;
                        case "InverseQ": parameters.InverseQ = Convert.FromBase64String(node.InnerText); break;
                        case "D": parameters.D = Convert.FromBase64String(node.InnerText); break;
                    }
                }
            }
            else
            {
                //throw new Exception("Invalid XML RSA key.");
            }

            rsa.ImportParameters(parameters);
            return "";

        }
        public static string GetXml(bool IsCreate,bool IncludePrivate)
        {
                if(IsCreate)
                    rsa = new RSACryptoServiceProvider(KeySize);
                return rsa.ToXmlString(IncludePrivate);
            
        }
        public static void GetPublicParameters(out string Modulus, out string Exponent)
        {
                RSAParameters rs = rsa.ExportParameters(false);
                Modulus = Convert.ToBase64String(rs.Modulus);
                Exponent = Convert.ToBase64String(rs.Exponent);            
        }
        public static string PublicEncrypt(string Source)
        {
            
                byte[] message = Encoding.UTF8.GetBytes(Source);

                int keySize = KeySize / 8;
                int maxLength = keySize - 42;
                int dataLength = message.Length;
                int iterations = dataLength / maxLength;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                    Buffer.BlockCopy(message, maxLength * i, tempBytes, 0, tempBytes.Length);
                    byte[] encryptedBytes = rsa.Encrypt(tempBytes, Padding);
                    //Array.Reverse(encryptedBytes);
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();                        
        }
        
        public static byte[]  PublicEncrypt(byte[] Source )
        {
            lock (rsa)
            {
                
                    byte[] message = Source;

                    int keySize = KeySize / 8;
                    int maxLength = keySize - 42;
                    int dataLength = message.Length;
                    int iterations = dataLength / maxLength;
                    StringBuilder stringBuilder = new StringBuilder();
                    List<byte> result = new List<byte>();
                    for (int i = 0; i <= iterations; i++)
                    {
                        lock (rsa)
                        {
                            byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                            Buffer.BlockCopy(message, maxLength * i, tempBytes, 0, tempBytes.Length);
                            byte[] encryptedBytes = rsa.Encrypt(tempBytes, Padding);
                            result.AddRange(encryptedBytes);
                        }
                    }
                    return result.ToArray();
                
            }
        }


        public static byte[] PrivateDecrypt(byte[] Source)
        {
            lock (rsa)
            {
                
                    //int base64BlockSize = ((KeySize / 8) % 3 != 0) ? (((KeySize / 8) / 3) * 4) + 4 : ((KeySize / 8) / 3) * 4;
                    //int iterations = Source.Length / base64BlockSize;
                    ArrayList arrayList = new ArrayList();
                    //for (int i = 0; i < iterations; i++)
                    //{
                    //    byte[] encryptedBytes = Convert.FromBase64String(Source.Substring(base64BlockSize * i, base64BlockSize));
                    //    //Array.Reverse(encryptedBytes);
                    //    arrayList.AddRange(rsa.Decrypt(encryptedBytes, Padding));
                    //}
                    List<byte[]> NewSource = new List<byte[]>();
                    while (Source.Any())
                    {
                        NewSource.Add(Source.Take(KeySize / 8).ToArray());
                        Source = Source.Skip(KeySize / 8).ToArray();
                    }
                    foreach (var item in NewSource)
                    {
                        arrayList.AddRange(rsa.Decrypt(item, Padding));
                    }
                    return arrayList.ToArray(Type.GetType("System.Byte")) as byte[];//; Encoding.UTF8.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
                
            }
        }

        public static string PrivateDecrypt(string Source)
        {
            
                int base64BlockSize = ((KeySize / 8) % 3 != 0) ? (((KeySize / 8) / 3) * 4) + 4 : ((KeySize / 8) / 3) * 4;
                //int base64BlockSize = 256;
                int iterations = Source.Length / base64BlockSize;
                ArrayList arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(Source.Substring(base64BlockSize * i, base64BlockSize));
                    //Array.Reverse(encryptedBytes);
                    arrayList.AddRange(rsa.Decrypt(encryptedBytes, Padding));
                }
                return Encoding.UTF8.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Main
        private static void GenerateByExistingParameters(string Modulus, string Exponent, string D, string DP, string DQ, string InverseQ, string P, string Q)
        {
           
                RSAParameters RSAKeyInfo = new RSAParameters();

                System.Numerics.BigInteger temp = System.Numerics.BigInteger.Parse(Modulus);
                RSAKeyInfo.Modulus = temp.ToByteArray();
                string tt = Convert.ToBase64String(temp.ToByteArray());

                temp = System.Numerics.BigInteger.Parse(Exponent);
                RSAKeyInfo.Exponent = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(D);
                RSAKeyInfo.D = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(DP);
                RSAKeyInfo.DP = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(DQ);
                RSAKeyInfo.DQ = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(InverseQ);
                RSAKeyInfo.InverseQ = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(P);
                RSAKeyInfo.P = temp.ToByteArray();

                temp = System.Numerics.BigInteger.Parse(Q);
                RSAKeyInfo.Q = temp.ToByteArray();

                //System.Numerics.BigInteger temp = System.Numerics.BigInteger.Parse("43235052418056264468861854318212235179840739562941856824887129688603875734132522320484275442649341699515733709041894020641037634410379162182061517408357978109592398159181353384308174917632507753875181619212921558844271434106730311692481759418409184472342222855180577939540720060020179367872147300444807084004");
                //RSAKeyInfo.Modulus = temp.ToByteArray();
                //string tt = Convert.ToBase64String(temp.ToByteArray());

                //temp = System.Numerics.BigInteger.Parse("65537");
                //RSAKeyInfo.Exponent = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("-38252881780438634454748772842379005075157193974655627763911154441465814943155145626417689686486390357513948170857416500791466490226542949426442009931944260837178278541738298557988154818333672418345938737071664833930372960713713970655340477229889024378351057530975573151419192904095971066576386791136415119133");
                //RSAKeyInfo.D = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("1986305576618583042180747445241766368172991783159014829602663052478100667177342381166696092530351009658376059375476392188945566832915655757151859649011158");
                //RSAKeyInfo.DP = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("5503405790446261908040684482460433511469948012168079955888998443315339873280788936643173673572781628628319645331853112215108362939138468330202469860309367");
                //RSAKeyInfo.DQ = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("2376025434908943257969477016477101936297112198687428824136975507289179867280612645154424769807095285620444998799293549606726198632735076567279719020794149");
                //RSAKeyInfo.InverseQ = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("-6108319205489391386014155005084149726810541329003766972343525728593453157661982381391967694788292024649734151901052933773565684118668926209598644027457800");
                //RSAKeyInfo.P = temp.ToByteArray();

                //temp = System.Numerics.BigInteger.Parse("4578496710795328730161784512080234077408071128771643215187777880720615549556663619150644448730800741189176254055074899619013087794333591588076724220078059");
                //RSAKeyInfo.Q = temp.ToByteArray();

                rsa.ImportParameters(RSAKeyInfo);
            
        }
        private static void AutoGenerate(out string Modulus, out string Exponent, out string D, out string DP, out string DQ, out string InverseQ, out string P, out string Q, out string xmlKey)
        {
                xmlKey = rsa.ToXmlString(true);
                RSAParameters rs = rsa.ExportParameters(true);
                Modulus = new System.Numerics.BigInteger(rs.Modulus).ToString();
                Exponent = new System.Numerics.BigInteger(rs.Exponent).ToString();
                D = new System.Numerics.BigInteger(rs.D).ToString();
                DP = new System.Numerics.BigInteger(rs.DP).ToString();
                DQ = new System.Numerics.BigInteger(rs.DQ).ToString();
                InverseQ = new System.Numerics.BigInteger(rs.InverseQ).ToString();
                P = new System.Numerics.BigInteger(rs.P).ToString();
                Q = new System.Numerics.BigInteger(rs.Q).ToString();
            
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static string PrivateEncrypt(string Key, string Source)
        {
            byte[] message = Encoding.UTF8.GetBytes(Source);
            //myRsa.LoadPrivateFromXMLString(Key);            
            //return (Convert.ToBase64String(myRsa.PrivateEncryption(message))); 

            return (Convert.ToBase64String(rsa.Encrypt(message, true)));

        }
        private static string PublicDecrypt(string Key, string Source)
        {
            byte[] message = Convert.FromBase64String(Source);
            //myRsa.LoadPublicFromXMLString(Key);
            //return (Encoding.UTF8.GetString(myRsa.PublicDecryption(message)));
            return (Encoding.UTF8.GetString(rsa.Decrypt(message, true)));
        }
        private static void readKey()
        {
            string PUBLIC_KEY = "c:\\netpublic.key"; //Generated by Java Program
            RSAParameters RSAKeyInfo = new RSAParameters();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string modStr = "", expStr = "";
            
                XmlTextReader reader = new XmlTextReader(PUBLIC_KEY);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Modulus")
                        {
                            reader.Read();
                            modStr = reader.Value;
                        }
                        else if (reader.Name == "Exponent")
                        {
                            reader.Read();
                            expStr = reader.Value;
                        }
                    }
                }
                if (modStr.Equals("") || expStr.Equals(""))
                {
                    throw new Exception("Invalid public key");
                }
                RSAKeyInfo.Modulus = Convert.FromBase64String(modStr);
                RSAKeyInfo.Exponent = Convert.FromBase64String(expStr);
                RSA.ImportParameters(RSAKeyInfo);
            
        }

        internal static string GetBase64Module()
        {
            return Convert.ToBase64String(rsa.ExportParameters(false).Modulus);
        }
    }

    public class Key
    {
        public string Mod;
        public string Exp;
        public Key(string Mod, string Exp)
        {
            this.Mod = Mod;
            this.Exp = Exp;
        }
    }
}
///-----------------------------------------------------------------------java
/*
///private String getRSAPublicKeyAsXMLString(RSAPublicKey key) throws
UnsupportedEncodingException,
      ParserConfigurationException,
      TransformerException {
    Document xml = getRSAPublicKeyAsXML(key);
Transformer transformer =
    TransformerFactory.newInstance().newTransformer();
StringWriter sw = new StringWriter();
transformer.transform(new DOMSource(xml), new StreamResult(sw));
    return sw.getBuffer().toString();
  }

  private Document getRSAPublicKeyAsXML(RSAPublicKey key) throws
      ParserConfigurationException,
      UnsupportedEncodingException {
    Document result =

DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
Element rsaKeyValue = result.createElement("RSAKeyValue");
result.appendChild(rsaKeyValue);
    Element modulus = result.createElement("Modulus");
rsaKeyValue.appendChild(modulus);

    byte[] modulusBytes = key.getModulus().toByteArray();
modulusBytes = stripLeadingZeros(modulusBytes);
modulus.appendChild(result.createTextNode(
        new String(new sun.misc.BASE64Encoder().encode(modulusBytes))));

    Element exponent = result.createElement("Exponent");
rsaKeyValue.appendChild(exponent);

    byte[] exponentBytes = key.getPublicExponent().toByteArray();
exponent.appendChild(result.createTextNode(
        new String(new sun.misc.BASE64Encoder().encode(exponentBytes))));

    return result;
  }
    */
///-----------------------------------------------------------------------java