using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Tools.General
{
    public class Hashing
    {
        

        public static string GetPacket(string Json, string PublicKey)
        {
            String Password = GetRandomPassword(24);
            byte[] Data = DES.EncryptGetBytes(Json, Password);
            byte[] PasswordBytes = Convert.FromBase64String(Password);

            int DataLen = Data.Length;
            int PasswordLen = PasswordBytes.Length;

            byte[] sendBytes = new byte[DataLen + PasswordLen];
            byte[] index = new byte[87];
            new Random().NextBytes(index);

            int packLen = DataLen / 4;

            List<byte[]> spPacket = new List<byte[]>();
            byte[] temp = new byte[2];
            for (int i = 0; i < 7; i++)
                spPacket.Add(temp);

            spPacket[0] = GetArray(PasswordBytes, 0, 8);
            spPacket[1] = GetArray(PasswordBytes, 8, 16);
            spPacket[2] = GetArray(PasswordBytes, 16, 24);
            spPacket[3] = GetArray(Data, 0, packLen);
            spPacket[4] = GetArray(Data, packLen, packLen * 2);
            spPacket[5] = GetArray(Data, packLen * 2, packLen * 3);
            spPacket[6] = GetArray(Data, packLen * 3, DataLen);
            List<UInt32> keyAddress = new List<UInt32>();
            List<UInt32> startDataAddress = new List<UInt32>();
            List<UInt32> lenAddress = new List<UInt32>();

            List<byte> randoms = new List<byte>();
            List<byte> keyOrder = new List<byte>();
            List<byte> dataOrder = new List<byte>();
            byte rand;
            UInt32 lastIndex = 0;

            for (byte i = 0; i < 7; i++)
            {
                while (randoms.Contains(rand = (byte)new Random().Next(0, 7))) { }
                randoms.Add(rand);

                if (rand < 3)
                {
                    keyOrder.Add(rand);
                    byte[] x = spPacket[rand];
                    keyAddress.Add(lastIndex);
                    Array.Copy(x, 0, sendBytes, lastIndex, x.Length);
                    lastIndex += (UInt32)x.Length;
                }
                else
                {
                    dataOrder.Add(rand);
                    byte[] x = (byte[])spPacket[rand];
                    startDataAddress.Add(lastIndex);
                    Array.Copy(x, 0, sendBytes, lastIndex, x.Length);

                    lastIndex += (UInt32)x.Length;
                    lenAddress.Add((UInt32)x.Length);
                }
            }

            {
                byte[] p1 = BitConverter.GetBytes(keyAddress[0]);
                byte[] p2 = BitConverter.GetBytes(keyAddress[1]);
                byte[] p3 = BitConverter.GetBytes(keyAddress[2]);

                index[7] = p1[0];
                index[8] = p1[1];
                index[65] = p1[2];
                index[66] = p1[3];


                index[13] = p2[0];
                index[14] = p2[1];
                index[67] = p2[2];
                index[68] = p2[3];

                index[19] = p3[0];
                index[20] = p3[1];
                index[69] = p3[2];
                index[70] = p3[3];
            }

            {
                byte[] s1 = BitConverter.GetBytes(startDataAddress[0]);
                byte[] s2 = BitConverter.GetBytes(startDataAddress[1]);
                byte[] s3 = BitConverter.GetBytes(startDataAddress[2]);
                byte[] s4 = BitConverter.GetBytes(startDataAddress[3]);

                byte[] e1 = BitConverter.GetBytes(lenAddress[0]);
                byte[] e2 = BitConverter.GetBytes(lenAddress[1]);
                byte[] e3 = BitConverter.GetBytes(lenAddress[2]);
                byte[] e4 = BitConverter.GetBytes(lenAddress[3]);

                index[25] = s1[0];
                index[26] = s1[1];
                index[71] = s1[2];
                index[72] = s1[3];

                index[27] = e1[0];
                index[28] = e1[1];
                index[73] = e1[2];
                index[74] = e1[3];

                index[31] = s2[0];
                index[32] = s2[1];
                index[75] = s2[2];
                index[76] = s2[3];


                index[33] = e2[0];
                index[34] = e2[1];
                index[77] = e2[2];
                index[78] = e2[3];

                index[37] = s3[0];
                index[38] = s3[1];
                index[79] = s3[2];
                index[80] = s3[3];


                index[39] = e3[0];
                index[40] = e3[1];
                index[81] = e3[2];
                index[82] = e3[3];

                index[42] = s4[0];
                index[43] = s4[1];
                index[83] = s4[2];
                index[84] = s4[3];


                index[44] = e4[0];
                index[45] = e4[1];
                index[85] = e4[2];
                index[86] = e4[3];
            }

            {
                index[49] = keyOrder[0];
                index[50] = keyOrder[1];
                index[51] = keyOrder[2];

                index[52] = dataOrder[0];
                index[53] = dataOrder[1];
                index[54] = dataOrder[2];
                index[55] = dataOrder[3];
            }
            long crc1 = GetCRC(sendBytes);
            byte[] crcByte1 = BitConverter.GetBytes(crc1);

            index[2] = crcByte1[0];
            index[3] = crcByte1[1];
            index[4] = crcByte1[2];
            index[5] = crcByte1[3];
            index[58] = crcByte1[4];
            index[59] = crcByte1[5];
            index[60] = crcByte1[6];
            index[61] = crcByte1[7];
            byte[] inPack = new byte[sendBytes.Length + 87];
            Array.Copy(index, 0, inPack, 0, index.Length);
            Array.Copy(sendBytes, 0, inPack, 87, sendBytes.Length);
            RSA.ImportXMLKey(PublicKey);

            byte[] outPack=RSA.PublicEncrypt(inPack);




            long crc = GetCRC(outPack);

            byte[] crcByte = BitConverter.GetBytes(crc);
            byte[] send = new byte[outPack.Length + 8];

            send[0] = crcByte[0];
            send[1] = crcByte[1];
            send[2] = crcByte[2];
            send[3] = crcByte[3];
            Array.Copy(outPack, 0, send, 4, outPack.Length);
            send[send.Length - 4] = crcByte[4];
            send[send.Length - 3] = crcByte[5];
            send[send.Length - 2] = crcByte[6];
            send[send.Length - 1] = crcByte[7];

            return Convert.ToBase64String(send);
        }

        public static string GetFields(string Input, string Key)
        {
            RSA.ImportXMLKey(Key);
            string Json = "";
            GetJason(Input, out Json, Key);
            return Json;
        }

        public static string GetJson(string Input, string Key)
        {
            RSA.ImportXMLKey(Key);
            string Json = "";
            GetJason(Input, out Json, Key);
            return Json;
        }

        public static string GetJason(string Input, out string Json, string Key)
        {
            if (Input.Length < 3)
            {
                Json = "";
                throw new Exception();
            }
            #region  Manage Public Key For Decrypting
            RSA.ImportXMLKey(Key);
            #endregion

            #region  Check First CRC
            byte[] InputArray = Convert.FromBase64String(Input);
            byte[] InputByte;
            CheckCRC(InputArray, out InputByte);
            #endregion

            #region RSA Decrypt
            byte[] RsaDec = RSA.PrivateDecrypt(InputByte);
            #endregion

            #region Extract DES Password & Packet & Decrypt
            string Password = "";
            byte[] EncDes = null;
            
                string Error = ExtractDesPassword(RsaDec, out Password, out EncDes);
                if (Error.Length > 0)
                {
                    RsaDec = Convert.FromBase64String(System.Text.Encoding.UTF8.GetString(RsaDec));
                    Error = ExtractDesPassword(RsaDec, out Password, out EncDes);
                    if (Error.Length > 0)
                    {
                        Json = "";
                        return (Error);
                    }
                }
            
            //Error = ExtractDesPassword(RsaDec, out Password, out EncDes);
            //if (Error.Length > 0)
            //{
            //    Json = "";
            //    return (Error);
            //}
            Json = DES.Decrypt(EncDes, Password);
            if (Error.Length > 0)
            {
                Json = "";
                return (Error);
            }
            return "";
            #endregion
        }
        public static long GetCRC(byte[] buffer)
        {
            var crc32 = new Crc32();
            var t = crc32.Get(buffer);
            return Convert.ToInt64(t);
        }

        public static byte[] GetArray(byte[] Source, int From, int To)
        {
            int Len = To - From;
            byte[] bytes = new byte[Len];

            for (int i = From; i < To; i++)
                bytes[i - From] = Source[i];

            return bytes;
        }

        public static String GetRandomPassword(int Len)
        {
            byte[] index = new byte[Len];
            new Random().NextBytes(index);
            return Convert.ToBase64String(index);
        }

        public static string CheckCRC(byte[] InputArray, out byte[] Input)
        {

            byte[] CRCByte = new byte[8];
            CRCByte[0] = InputArray[0];
            CRCByte[1] = InputArray[1];
            CRCByte[2] = InputArray[2];
            CRCByte[3] = InputArray[3];
            CRCByte[4] = InputArray[InputArray.Length - 4];
            CRCByte[5] = InputArray[InputArray.Length - 3];
            CRCByte[6] = InputArray[InputArray.Length - 2];
            CRCByte[7] = InputArray[InputArray.Length - 1];
            long CRC = BitConverter.ToInt64(CRCByte, 0);
            byte[] newArray = new byte[InputArray.Length - 8];
            for (int i = 4; i < InputArray.Length - 4; i++)
            {
                newArray[i - 4] = InputArray[i];
            }
            long CalcCRC = GetCRC(newArray);
            // Input = Convert.ToBase64String(newArray);
            Input = newArray;
            if (CRC != CalcCRC)
                throw new Exception();
            return ("");
        }
        public static string ExtractDesPassword(byte[] Input, out string Password, out byte[] DES)
        {
            string Error = "";
            byte[] InputArray = Input;

            #region Check CRC
            long AndroidCRC = GetDeviceCRC(InputArray);
            Password = "";
            DES = null;
            byte[] MainPacket = new byte[InputArray.Length - 87];

            for (int i = 0; i < InputArray.Length - 87; i++)
                MainPacket[i] = InputArray[i + 87];

            long ReceivedCRC = GetCRC(MainPacket);
            if (AndroidCRC != ReceivedCRC)
            {
                Password = "";
                DES = null;
                return "  ";
            }


            #endregion

            #region Get Password
            Error = GetPassword(InputArray, out Password);
            //byte[] PasswordBytes = Convert.FromBase64String(Password);

            if (Error.Length > 0)
            {
                Password = "";
                DES = null;
                return (Error);
            }
            #endregion

            #region Get DES
            byte[] DesArray = null;
            Error = GetDes(InputArray, out DesArray);
            if (Error.Length > 0)
            {
                Password = "";
                DES = null;
                return (Error);
            }
            DES = DesArray;//;Convert.ToBase64String(InputArray);
            #endregion

            return "";
        }
        private static string GetDes(byte[] inputArray, out byte[] DesArray)
        {

            List<CSPacket> Packets = new List<CSPacket>();
            Packets.Add(new CSPacket(inputArray[52], GetShort(inputArray, 27, 28, 73, 74), GetShort(inputArray, 25, 26, 71, 72)));
            Packets.Add(new CSPacket(inputArray[53], GetShort(inputArray, 33, 34, 77, 78), GetShort(inputArray, 31, 32, 75, 76)));
            Packets.Add(new CSPacket(inputArray[54], GetShort(inputArray, 39, 40, 81, 82), GetShort(inputArray, 37, 38, 79, 80)));
            Packets.Add(new CSPacket(inputArray[55], GetShort(inputArray, 44, 45, 85, 86), GetShort(inputArray, 42, 43, 83, 84)));

            Packets = Packets.OrderBy(o => o.Order).ToList();

            byte[] Des = new byte[Packets[0].Len + Packets[1].Len + Packets[2].Len + Packets[3].Len];

            Array.Copy(inputArray, Packets[0].Address, Des, 0, Packets[0].Len);
            Array.Copy(inputArray, Packets[1].Address, Des, Packets[0].Len, Packets[1].Len);
            Array.Copy(inputArray, Packets[2].Address, Des, Packets[0].Len + Packets[1].Len, Packets[2].Len);
            Array.Copy(inputArray, Packets[3].Address, Des, Packets[0].Len + Packets[1].Len + Packets[2].Len, Packets[3].Len);

            DesArray = Des;
            return ("");
        }
        private static string GetPassword(byte[] inputArray, out string Password)
        {

            List<byte> order = new List<byte>();
            List<UInt32> Addresses = new List<UInt32>();
            for (int i = 49; i < 52; i++)
                order.Add(inputArray[i]);

            Addresses.Add(GetShort(inputArray, 7, 8, 65, 66));
            Addresses.Add(GetShort(inputArray, 13, 14, 67, 68));
            Addresses.Add(GetShort(inputArray, 19, 20, 69, 70));

            Addresses[0] += 87;
            Addresses[1] += 87;
            Addresses[2] += 87;

            byte[] Pass = new byte[24];
            for (int i = 0; i < 3; i++)
                Array.Copy(inputArray, Addresses[i], Pass, order[i] * 8, 8);

            Password = Convert.ToBase64String(Pass);
            return ("");
        }
        private static UInt32 GetShort(byte[] inputArray, int index1, int index2, int index3, int index4)
        {
            byte[] Location = new byte[4];
            Location[0] = inputArray[index1];
            Location[1] = inputArray[index2];
            Location[2] = inputArray[index3];
            Location[3] = inputArray[index4];
            var i = BitConverter.ToUInt32(Location, 0);
            return i;
        }
        private static long GetDeviceCRC(byte[] inputArray)
        {
            byte[] Location = new byte[8];
            Location[0] = inputArray[2];
            Location[1] = inputArray[3];
            Location[2] = inputArray[4];
            Location[3] = inputArray[5];
            Location[4] = inputArray[58];
            Location[5] = inputArray[59];
            Location[6] = inputArray[60];
            Location[7] = inputArray[61];
            return BitConverter.ToInt64(Location, 0);
        }
    }

    public class CSPacket
    {
        public Int64 Order { get; set; }
        public Int64 Len { get; set; }
        public Int64 Address { get; set; }

        public CSPacket(byte Order, UInt32 Len, UInt32 Address)
        {
            this.Order = Order;
            this.Len = Len;
            this.Address = Address + 87;
        }
    }
}
