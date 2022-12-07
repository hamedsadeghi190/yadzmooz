using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.GlobalSettings
{
    public  class PaySettings
    {
        public static string ApiKey { get; set; }
        public static string CollectionId { get; set; }
        public static string CallbackUrl { get; set; }
        public static string RedirectUrl { get; set; }
        public static string Host { get; set; }
    }
}
