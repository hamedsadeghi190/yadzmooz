using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.GlobalSettings
{
    public class PaymentData
    {
        public static string Account { get; set; }
        public static string MobileAddress { get; set; }
        public static string WebAddress { get; set; }
        public static string SiteAddress { get; set; }
        public static string MobileActivity{ get; set; }
        public static string Title { get; set; }
        public static string Email { get; set; }
        public static string MaxPayment { get; set; }
    }
}
