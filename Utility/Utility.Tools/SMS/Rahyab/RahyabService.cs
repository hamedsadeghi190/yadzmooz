using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class RahyabService : INotification
    {
        private readonly IConfiguration configuration;

        public RahyabService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> SendAsync(string Text, string Destination)
        {
            configuration.GetSection<RahyabParameters>();
            Cls_SMS.ClsSend sms_Single = new Cls_SMS.ClsSend();
            var a = sms_Single.SendSMS_Single(Text, Destination);
            if (a != null && a.Length > 0)
                return a[0];
            return "";
        }


    }

}
