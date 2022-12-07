using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.GlobalSettings
{
    public class AdminSettings
    {
        public static string BlockCount { get; set; }
        public static string Root { get; set; }
        public static string SMSCode { get; set; }
        public static int Block => BlockCount.ToInt();

        public static string SMSName { get; set; }
        public static string SMSTitle { get; set; }
        public static string Enables { get; set; }
    }
}
