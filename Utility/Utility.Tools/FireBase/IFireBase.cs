using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Tools
{
    public interface IFireBase
    {
        string SendNotification(List<string> devices, object not, string click);        
    }


    public class NotificationObject
    {
        public string click_action { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public Guid? FromId { get; set; }
        public string FromName { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }        
        public double? KargozariLat { get; set; }
        public double? KargozariLon { get; set; }
        public Guid ProcessId { get; set; }
        public double? DestinationLat { get; set; }
        public double? DestinationLon { get; set; }
        public string KargozariName { get; set; }

        //public DeliveryFireBase Object { get; set; }
    }

    public class SpecialObject
    {
        
    }

    
    public class Payload 
    {
        public string to { get; set; }                                        
        public object data { get; set; }

    };

}
