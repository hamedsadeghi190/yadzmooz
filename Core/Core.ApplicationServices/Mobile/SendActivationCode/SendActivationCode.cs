using Core.Entities.Dto;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Utility.Tools.General;
using Utility.Tools.Notification;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using RestSharp;

namespace Core.ApplicationServices
{
    public class SendActivationCode : ISendActivationCode
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public SendActivationCode
            (
            IUnitOfWork unit
            , INotification notification,
            IConfiguration configuration
            )
        {
            this.unit = unit;
            this.notification = notification;
            this.configuration = configuration;
        }


        public SendActivationCodeResultDto Execute(SendActivationCodeDto dto)
        {

            this.configuration.GetSection<OTPConfig>();



            SendActivationCodeResultDto result = new SendActivationCodeResultDto { Message = Messages.LimitExceeded, IsSuccess = false, Code = 101 };
            var now = Agent.UnixTimeNow();



            if (!unit.ActivationCodes.CheckExeed(dto.Mobile)){
                string Code = Agent.GenerateCode();

                var url = "https://sms.raimun.com/api/v1/Messages/send" + $"?Authentication=44461c41-6e72-4043-9814-c72df742215e";
                var sendOtpDto = new SendActivationCodeApiDto
                {
                    receiver = dto.Mobile,
                    param = Code,
                    patternId = "61b1e5928bf66588dbe273cb"
                };

                var client = new RestClient("https://sms.raimun.com/api/v1/Messages/send");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authentication", "44461c41-6e72-4043-9814-c72df742215e");
                request.AddHeader("accept", " text/plain");
                request.AddHeader("Content-Type", "application/json");
                var body = System.Text.Json.JsonSerializer.Serialize(sendOtpDto);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);





                unit.ActivationCodes.Insert(new ActivationCode() { Mobile = dto.Mobile, Code = Code, CreatedAt = now });

                //var sent = $"{AdminSettings.SMSName}\n{AdminSettings.SMSTitle} : {Code}\n";


                //Task myTask = Task.Run(() => notification.SendAsync(sent, dto.Mobile));
                //myTask.Wait();

                result.Message = Messages.OK;
                result.Code = StatusCodes.Successful;
                result.IsSuccess = true;
            }
            return result;

        }
    }
}
