using CorePush.Google;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Utility.Tools
{
    public class NewFireBase : INewFireBase
    {
        private readonly IConfiguration configuration;

        public NewFireBase(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool SendNotification(string[] devices, string title, string body, object data)
        {
            var pushSent = false;
            Task myTask = Task.Run(() => pushSent = SendPushNotification(devices, title, body, data).Result);

            return pushSent;
        }

        public  async Task<bool> SendPushNotification(string[] deviceTokens, string title, string body, object data)
        {
            bool sent = false;
            configuration.GetSection<FireBaseSetting>();

            if (deviceTokens.Count() > 0)
            {
                //Object creation

                var messageInformation = new UtilNotificationMessage()
                {
                    notification = new UtilNotificationObject()
                    {
                        title = title,
                        body = body
                    },
                    data = data,
                    registration_ids = deviceTokens
                };

                //Object to JSON STRUCTURE => using Newtonsoft.Json;
                string jsonMessage = JsonConvert.SerializeObject(messageInformation);

                /*
                 ------ JSON STRUCTURE ------
                 {
                    notification: {
                                    title: "",
                                    text: ""
                                    },
                    data: {
                            action: "Play",
                            playerId: 5
                            },
                    registration_ids = ["id1", "id2"]
                 }
                 ------ JSON STRUCTURE ------
                 */

                //Create request to Firebase API
                var request = new HttpRequestMessage(HttpMethod.Post, FireBaseSetting.FireBaseApiAddress);

                request.Headers.TryAddWithoutValidation("Authorization", "key=" + FireBaseSetting.AuthorizationKey);
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                HttpResponseMessage result;
                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                    sent = sent && result.IsSuccessStatusCode;
                }
            }

            return sent;
        }

    }



}
