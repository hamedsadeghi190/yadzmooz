using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QRCoder;
using SkiaSharp;
using SkiaSharp.QrCode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Utility.Tools.General
{
    public static class Agent
    {
        private static readonly IConfiguration configuration;


        public delegate IFireBase ServiceResolver(string key);
        public static string JSONSerialize(object obj)
        {
            string result = JsonConvert.SerializeObject(obj);
            result = result.TrimStart('\"');
            result = result.TrimEnd('\"');
            result = result.Replace("\\", "");
            return result;
        }
        public static string GetTdButton(string Text, string Controller, string Action, string Id, string Class)
        {

            string result = $"<td><input type=\"button\" class=\"{ Class}\" value=\"{Text}\" onclick=getAddress('{Controller}','{Action}','{Id}')></td>";
            return result;
        }

        public static long StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date.ToUnix();
        }

        public static int GenerateRandomNoRange(int a , int b)
        {
            Random r = new Random();
            int rInt = r.Next(a, b);
            return rInt;
        }

        public static DateTime StartOfWeek(this DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static long LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = StartOfWeek(date).AddDays(6);
            return ldowDate.ToUnix();
        }
        public static long FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1).ToUnix();
        }

        public static long LastDayOfMonth(this DateTime value)
        {
            return value.Date.AddDays(DateTime.DaysInMonth(value.Year, value.Month) - value.Day).ToUnix();
        }


        public static string GetSerialKeyAlphaNumaric(SNKeyLength keyLength)
        {
            string newSerialNumber = "";
            string SerialNumber = Guid.NewGuid().ToString("N").Substring(0, (int)keyLength).ToUpper();
            for (int iCount = 0; iCount < (int)keyLength; iCount += 4)
                newSerialNumber = newSerialNumber + SerialNumber.Substring(iCount, 4) + "-";
            newSerialNumber = newSerialNumber.Substring(0, newSerialNumber.Length - 1);
            return newSerialNumber;
        }

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var rlat1 = Math.PI * lat1 / 180;
            var rlat2 = Math.PI * lat2 / 180;
            var rlon1 = Math.PI * lon1 / 180;
            var rlon2 = Math.PI * lon2 / 180;
            var theta = lon1 - lon2;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344 * 1000;
            return dist;
        }

        public static long Now => DateTime.Now.ToUnix();
        public static void InsertLog(string message)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"Logs\NikoService.txt";
                string pd = DateTime.Now.ToString();
                string msg = pd + '\t' + message;
                if (!File.Exists(path))
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(msg);
                    }
                else
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(msg);
                    }
            }
            catch (Exception)
            {
            }
        }
        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        public static long GetStartDate(long createAt)
        {
            return createAt.ToDate().Date.ToUnix();
        }

        public static long GetEndDate(long createAt)
        {
           return createAt.ToDate().Date.AddTicks(-1).AddDays(1).ToUnix();
        }



        public static void SaveFile(byte[] file, string address)
        {
            FileStream sw = new FileStream(address, FileMode.Create);
            byte[] Bytes = file;
            sw.Write(Bytes, 0, Bytes.Length);
            sw.Close();
        }

        public static List<T> CastObjToList<T>(T Obj)
        {
            if (Obj != null)
            {
                List<T> temp = new List<T>();
                temp.Add(Obj);
                return temp;
            }
            return new List<T>();
        }

        public static void MapAllFields(object source, object dst, string FieldName)
        {
            var ps = source.GetType().GetProperties();
            foreach (var item in ps)
            {
                if (item.Name != FieldName)
                {
                    var o = item.GetValue(source);
                    var p = dst.GetType().GetProperty(item.Name);
                    if (p != null)
                    {
                        if (o != null)
                        {
                            try
                            {
                                Type t = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                                object safeValue = (o == null) ? null : o;// Convert.ChangeType(o, t);
                                p.SetValue(dst, safeValue);
                            }
                            catch { }
                        }
                    }
                }
            }
        }



        public static long UnixOfTime(DateTime dateTime)
        {
            var timeSpan = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }


        public static DateTime GetToday(int Plus)
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, 0, 0, 1).AddDays(Plus);
        }


        public static Type GetTables(string Name)
        {
            return Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsClass & t.Name == Name);
        }

        public static void FileLogger(string FileName, string text)
        { 
 
            using (StreamWriter outputFile = new StreamWriter(FileName, true))
            {
                outputFile.WriteLine(DateTime.Now.ToString() + " : " + text);
            }
        }

        public static T FromJson<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static string GenerateCode()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }

        public static string GenerateRandomNo(int Count)
        {
            int _min = (int)Math.Pow(10, Count - 1);
            int _max = (int)Math.Pow(10, Count) - 1;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString().PadLeft(5, '0');
        }
        public static string GenerateCaptcha(int Count)
        {
            string result = "";
            string baseStr = "sa5u3kad9u90sda4mp4p67h46sd4";
            Random _rdm = new Random();
            for (int i = 0; i < Count; i++)
            {
                result += baseStr[_rdm.Next(baseStr.Length)].ToString();
            }
            return result;
        }


        public static string GetError(Exception exception)
        {
            if (exception.Message.Contains("NikoErrorText"))
                return MakeError(exception.Message);
            try
            {
                StackTrace trace = new StackTrace(exception, true);
                var frame = trace.GetFrame(2);


                string text = exception.StackTrace;
                string Line = text.Substring(text.IndexOf("ApplicationServices"));
                Line = Line.Substring(0, Line.IndexOf(" at"));
                string fileName = Line.Split(':')[0];
                Line = Line.Split(':')[1].Replace("line", "").Replace("\r\n", "").Trim();

                Line = frame.GetFileLineNumber().ToString();
                fileName = frame.GetFileName();

                var result = CreateException(exception);

                return MakeError(result);
            }
            catch
            {
                return MakeError(ToJson(new { NikoError = exception.Message, NikoErrorText = "خطا", NikoErrorCode = "2" }));
            }
        }

        public static string CreateException(Exception ex)

        {

            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);

            string diagnoseResults = "";

            for (int i = 0; i < trace.FrameCount; i++)

            {

                diagnoseResults += i.ToString() + ":" + trace.GetFrame(i).GetMethod().Name + ":" + trace.GetFrame(i).GetFileLineNumber() + ":" + trace.GetFrame(0).GetFileColumnNumber() + "-";

            }

            string[] diagnoseBlocks = diagnoseResults.Split(new char[] { '-' });

            string processesException = "";

            processesException += "Exception Code = " + "12" + "\r\n";

            processesException += "Exception Message = " + "dddd" + "\r\n";

            processesException += "Exception Class = " + ex.TargetSite.ReflectedType.Name + "\r\n\r\n";

            processesException += "Exception Path:\r\n";

            processesException += "===============\r\n";

            for (int i = 0; i < diagnoseBlocks.Length - 1; i++)

            {

                string[] diagnoseCell = diagnoseBlocks[i].Split(new char[] { ':' });

                processesException += "Exception Level = " + i.ToString() + "\r\n";

                processesException += "Exception Method = " + diagnoseCell[1].ToString() + "\r\n";

                processesException += "Exception Line number = " + diagnoseCell[2].ToString() + "\r\n";

                processesException += "Exception Column number = " + diagnoseCell[3].ToString() + "\r\n\r\n";

            }

            return "$" + processesException + "$";

        }



        public static string MakeResponse(string Response)
        {
            return ToJson(new { Response });
        }

        public static string MakeError(string Response)
        {
            return ToJson(new { Error = Response });
        }

        public static string ToJson(object Obj)
        {
            return JsonConvert.SerializeObject(Obj, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore
                            //,Error = Han
                        });
        }


        public static string Encrypt(string text)
        {
            return DES.Encrypt(text, "AArIFHhOAi2fqmA/FCr6TtQKYgFO5je+");
        }
        public static string Decrypt(string text)
        {
            return DES.Decrypt(text, "AArIFHhOAi2fqmA/FCr6TtQKYgFO5je+");
        }

        public static string EncryptRsa(string text, string PublicKey)
        {
            //Agent.FileLogger("Encrypt: " + PublicKey);
            return Hashing.GetPacket(text, PublicKey);
        }
        public static string DecryptRsa(string text, string Key)
        {
            return Hashing.GetFields(text, Key);
        }
        public static List<List<object>> ReadExcel(string path)
        {
            List<List<object>> res = new List<List<object>>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        List<object> values = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            {
                                values.Add(reader.GetValue(i));
                            }
                            catch (Exception)
                            {
                            }
                        }
                        res.Add(values);
                    }
                }
            }
            return res;
        }


        public static byte[] GenerateQrCode(Guid id)
        {

            var content = "https://makanavenue.com/download?id=" + id.ToString();
            using var generator = new SkiaSharp.QrCode.QRCodeGenerator();

            var level = ECCLevel.H;
            var qr = generator.CreateQrCode(content, level);

            var info = new SKImageInfo(512, 512);
            using var surface = SKSurface.Create(info);

            var canvas = surface.Canvas;
            canvas.Render(qr, 512, 512);

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);

            //var path = /*AdminSettings.Root + */@"D:\test\" + @$"{id}.png";
            //using var stream = File.OpenWrite(path);
            //data.SaveTo(stream);

            

            //byte[] bytes = new byte[stream.Length];
            //stream.Write(bytes, 0, (int)stream.Length);
            return data.ToArray();


        }

        
    }

    public enum SNKeyLength
    {
        SN4 = 4, SN8 = 8, SN12 = 12
    }
}
