
using System;
using System.Collections.Generic;

namespace Utility.Tools
{
    public class UtilNotificationMessage
    {
        public string[] registration_ids { get; set; }
        public UtilNotificationObject notification { get; set; }
        public object data { get; set; }
    }
    public class UtilNotificationObject
    {
        public string title { get; set; }
        public string body { get; set; }
    }

}
