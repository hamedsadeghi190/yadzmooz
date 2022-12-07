using CorePush.Google;
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
    public class DeliveryFireBase : IFireBase
    {
        private readonly IConfiguration configuration;

        public DeliveryFireBase(IConfiguration configuration)
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
            configuration.GetSection<DeliveryFireBaseSetting>();


            foreach (var pushId in devices)
            {
                try
                {
                    using var fcm = new FcmSender(DeliveryFireBaseSetting.AuthorizationKey, DeliveryFireBaseSetting.Sender);
                    var res = await fcm.SendAsync(pushId,
                        new FCMObject
                        {
                            notification = new Not
                            {
                                title = FireBaseSetting.FireBaseTitle,
                                body = notification,
                                sound = "ringtone"
                            },
                            data = not/*new Data { click_action = click }*/
                        }
                        );
                    resultStr += res.Success.ToString();

                }
                catch (Exception e1)
                {

                    resultStr += e1.ToString();
                }
                //WebRequest tRequest = WebRequest.Create(FireBaseSetting.FireBaseApiAddress);
                //tRequest.Method = "post";
                //tRequest.Headers.Add(string.Format("Authorization: key={0}", FireBaseSetting.AuthorizationKey));
                //tRequest.Headers.Add(string.Format("Sender: id={0}", FireBaseSetting.Sender));
                //tRequest.ContentType = "application/json";

                //Payload payload = new Payload
                //{
                //    to = item.DeviceId,                                                                                
                //    data = item
                //};
                //string postbody = Agent.ToJson(payload);
                //Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                //tRequest.ContentLength = byteArray.Length;
                //using (Stream dataStream = tRequest.GetRequestStream())
                //{
                //    dataStream.Write(byteArray, 0, byteArray.Length);
                //    using (WebResponse tResponse = tRequest.GetResponse())
                //    {
                //        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                //        {
                //            if (dataStreamResponse != null)
                //                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                //                {
                //                    String sResponseFromServer = tReader.ReadToEnd();
                //                    resultStr += sResponseFromServer;
                //                }
                //        }
                //    }

                //}
                Thread.Sleep(100);
            }
            return resultStr;
        }


    }

  

    


}
