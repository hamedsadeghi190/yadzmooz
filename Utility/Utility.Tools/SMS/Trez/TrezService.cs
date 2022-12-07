using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class TrezService : INotification
    {
        private readonly IConfiguration configuration;

        public TrezService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> SendAsync(string Text, string Destination)
        {
            configuration.GetSection<TrezParameters>();
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["Username"] = TrezParameters.UserName;// "iranpetrol";
                values["Password"] = TrezParameters.Password; //"bonnie2019";
                values["PhoneNumber"] = TrezParameters.PhoneNumber;// "50002210004082";
                values["MessageBody"] = Text;
                values["RecNumber"] = Destination;
                values["Smsclass"] = "1";

                //"http://smspanel.Trez.ir/SendMessageWithPost.ashx"
                var response = client.UploadValues(TrezParameters.WebServiceAddress, values);

                var responseString = Encoding.Default.GetString(response);
                return null;
            }
        }
    }
}