using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.General
{
    public class AdminSettings
    {
        public static string BlockCount { get; set; }
        public static string Root { get; set; }
        public static string SMSCode { get; set; }
        public static int Block => BlockCount.ToInt();
        public static string SMSName { get; set; }
        public static string DownloadLinkIndex { get; set; }
        public static string SMSTitle { get; set; }
        public static string Enables { get; set; }
        public static string SMSMaximumAllowed { get; set; }
        public static string FoxPro { get; set; }
        public static string FailedLoginLocked { get; set; }
        public static int TablesBlock { get; set; }
    }

    public class LinkManager
    {
        public List<string> DownloadLinks { get; set; }
        public int DownloadLinkIndex { get; set; }
    }
}
