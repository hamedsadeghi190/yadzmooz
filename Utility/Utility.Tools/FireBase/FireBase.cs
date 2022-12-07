using CorePush.Google;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools;
using Utility.Tools.General;

namespace Utility.Tools
{
    public class FireBase : IFireBase
    {
        private readonly IConfiguration configuration;

        public FireBase(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string SendNotification(List<string> devices, object not, string notification)
        {
            var result = "";

            Task myTask = Task.Run(() => result = Run(devices, not, notification).Result);
            myTask.Wait();
            return result;
        }

        private async Task<string> Run(List<string> devices, object not, string notification)
        {
            string resultStr = "";
            configuration.GetSection<FireBaseSetting>();


            foreach (var pushId in devices)
            {
                try
                {
                    using var fcm = new FcmSender(FireBaseSetting.AuthorizationKey, FireBaseSetting.Sender);
                    //var res = await fcm.SendAsync(pushId,not);                    
                    var res = await fcm.SendAsync(pushId, not);

                    resultStr += res.Success.ToString();

                }
                catch (Exception e1)
                {

                    resultStr += e1.ToString();
                }
                WebRequest tRequest = WebRequest.Create(FireBaseSetting.FireBaseApiAddress);
                tRequest.Method = "post";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", FireBaseSetting.AuthorizationKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", FireBaseSetting.Sender));
                tRequest.ContentType = "application/json";


                Payload payload = new Payload
                {
                    to = pushId,
                    data = not
                };


                string postbody = Agent.ToJson(payload);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null)
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    resultStr += sResponseFromServer;
                                }
                        }
                    }

                }
                Thread.Sleep(100);
            }
            return resultStr;
        }


    }

    public class FCMObject
    {
        public Not notification { get; set; }
        public object data { get; set; }
    }
    public class Not
    {
        public string title { get; set; }
        public object body { get; set; }
        public string sound{ get; set; }
    }

    


}
