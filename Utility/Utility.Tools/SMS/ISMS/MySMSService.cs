using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;
using System.Net;
using System.IO;

namespace Utility.Tools.SMS.Rahyab
{
    public class MySMSService : INotification
    {
        private readonly IConfiguration configuration;

        public MySMSService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> SendAsync(string Text, string Destination)
        {
            //Cls_SMS.ClsSend sms_Single = new Cls_SMS.ClsSend();
            //var a = sms_Single.SendSMS_Single(Text, Destination);
            //if (a != null && a.Length > 0)
            //    return a[0];

            configuration.GetSection<MySMSParameters>();

            Uri myUri = new Uri(MySMSParameters.Address + MySMSParameters.Username + "&pwd=" + MySMSParameters.Password + "&dstno=" + Destination + "&agreedterm="+  MySMSParameters.agreedterm  + "&msg=" + Text + "&type=" + MySMSParameters.Type + "&sendid=\"issms\"");

            // Create a new request to the above mentioned URL.
            WebRequest myWebRequest = WebRequest.Create(myUri);

            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            WebResponse myWebResponse = myWebRequest.GetResponse();

            StreamReader reader = new StreamReader(myWebResponse.GetResponseStream());

            string s_ResponseString = reader.ReadToEnd();

            return s_ResponseString;
        }


    }

}
