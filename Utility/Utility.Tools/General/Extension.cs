using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using Utility.Tools.General;

namespace System
{
    public static class Extension
    {
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static void GetSection<T>(this IConfiguration config)
        {
            var data = config.GetSection(typeof(T).Name).Get<Dictionary<string, object>>();
            Type type = typeof(T);
            foreach (var p in type.GetProperties())
            {
                object Value = null;
                data.TryGetValue(p.Name, out Value);
                if (Value != null)
                    p.SetValue(null, Value);
            }
        }
        public static T GetSectionByObject<T>(this IConfiguration config)
        {
            var Obj = (T)Activator.CreateInstance(Type.GetType(typeof(T).ToString()));
            var section = config.GetSection("DownloadLinks");
            section.Bind(Obj);
            return Obj;
        }
        public static string GetSection(this IConfiguration config, string Name)
        {
            var data = config.GetSection(Name).Get<Dictionary<string, string>>();
            return Agent.ToJson(data);
        }

        public static int ToInt(this Enum Code)
        {
            return (int)Convert.ChangeType(Code, Code.GetTypeCode());
        }
        public static T BindSection<T>(this IConfiguration config) where T:class
        {
            var options = (T)Activator.CreateInstance(typeof(T));            
            var section = config.GetSection(typeof(T).Name);
            section.Bind(options);
            return options;
        }

        public static int ToInt(this Guid guid)
        {
            byte[] _bytes = guid.ToByteArray();
            return ((int)_bytes[0]) | ((int)_bytes[1] << 8) | ((int)_bytes[2] << 16) | ((int)_bytes[3] << 24);
        }
        public static Guid ToGuid(this int num)
        {
            return new Guid(num, 0, 0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        public static string ToMonth(this int MonthMo)
        {
            switch (MonthMo)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "Augu";
                case 9:
                    return "Sept";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Des";
            }
            return "";
        }

        public static string ToEnglish(this string num)
        {
            string numresult = "";
            for (int i = 0; i < num.Length; i++)
            {
                string numt = num.Substring(i, 1);
                switch (numt)
                {
                    case "١":
                    case "1":
                        numresult += "1";
                        break;
                    case "٢":
                    case "2":
                        numresult += "2";
                        break;
                    case "٣":
                    case "3":
                        numresult += "3";
                        break;
                    case "٤":
                    case "4":
                        numresult += "4";
                        break;
                    case "٥":
                    case "5":
                        numresult += "5";
                        break;
                    case "٦":
                    case "6":
                        numresult += "6";
                        break;
                    case "٧":
                    case "7":
                        numresult += "7";
                        break;
                    case "٨":
                    case "8":
                        numresult += "8";
                        break;
                    case "٩":
                    case "9":
                        numresult += "9";
                        break;
                    case "٠":
                    case "0":
                        numresult += "0";
                        break;
                    default:
                        numresult += numt;
                        break;
                }

            }
            return numresult;
        }
        public static string GetUrlFileName(this string url)
        {
            Uri uri = new Uri(url);
            return System.IO.Path.GetFileName(uri.LocalPath);
        }
        public static string ToPersian(this string num)
        {
            string numresult = "";
            for (int i = 0; i < num.Length; i++)
            {
                string numt = num.Substring(i, 1);
                switch (numt)
                {
                    case "١":
                    case "1":
                        numresult += "١";
                        break;
                    case "٢":
                    case "2":
                        numresult += "٢";
                        break;
                    case "٣":
                    case "3":
                        numresult += "٣";
                        break;
                    case "٤":
                    case "4":
                        numresult += "٤";
                        break;
                    case "٥":
                    case "5":
                        numresult += "٥";
                        break;
                    case "٦":
                    case "6":
                        numresult += "٦";
                        break;
                    case "٧":
                    case "7":
                        numresult += "٧";
                        break;
                    case "٨":
                    case "8":
                        numresult += "٨";
                        break;
                    case "٩":
                    case "9":
                        numresult += "٩";
                        break;
                    case "٠":
                    case "0":
                        numresult += "٠";
                        break;
                    default:
                        numresult += numt;
                        break;
                }

            }
            return numresult;
        }
        public static int ToInt(this string num)
        {
            return int.Parse(num);
        }
     

     
       
      
   
        public static long ToUnix(this DateTime date)
        {
            var timeSpan = (date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

      

        public static DateTime SubDays(this long day, int days)
        {
            var dateTime = day.ToDate();
            DateTime dtDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 1);
            return dtDateTime.AddDays(days);
        }
        public static DateTime SubDays(this DateTime dateTime, int days)
        {
            DateTime dtDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 1);
            return dtDateTime.AddDays(days);
        }
        public static Guid ToGuid(this object obj)
        {
            return (Guid)obj;
        }
      
        public static string DayName(this long date)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(date).ToLocalTime();
            return dtDateTime.DayOfWeek.ToString();
        }
     

      




        public static string Description<T>(this T enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetDescription();
        }

        public static string Name<T>(this T enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        public static string SafeFarsiStr(this string input)
        {
            return input.Replace("ي", "ی").Replace("ك", "ک");
        }



        

       

        public static DateTime ToDate(this int date)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime.AddSeconds(date).ToLocalTime();
        }

        public static string ToDateLongString(this int date)
        {
            return date.ToDate().ToString();
        }

       

        public static DataTable ToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public static DataTable ClassToDataTable(this object ClassObj)
        {
            var dataTable = new DataTable("OutputData");

            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);

            ClassObj.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(ClassObj, null);
                    dataTable.Columns.Add(f.Name, f.PropertyType);
                    dataTable.Rows[0][f.Name] = f.GetValue(ClassObj, null);
                }
                catch { }
            });
            return dataTable;
        }


      

        public static DateTime ToDate(this long date)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime.AddSeconds(date).ToLocalTime();
        }

        public static string ToDateLongString(this long date)
        {
            return date.ToDate().ToString();
        }

    }
}

