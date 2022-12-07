using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;
using ServiceReference1;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Core.ApplicationServices
{
    public class VerifySubscription : IVerifySubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;
        private readonly IPaymentGateway paymentGateway;

        public VerifySubscription
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler,
            IPaymentGateway paymentGateway
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
            this.paymentGateway = paymentGateway;
        }


        public VerifySubscriptionResultDto Execute(VerifySubscriptionDto dto)
        {

    







            long TerminalId = 5799270;
            string UserName = "Parman123";
            string UserPassword = "55180195";





            var result = paymentGateway.bpVerifyRequest(new bpVerifyRequest
            {
                Body = new bpVerifyRequestBody
                {
                    orderId = 10,
                    saleOrderId = 10,
                    saleReferenceId = 0,
                    terminalId = TerminalId,
                    userName = UserName,
                    userPassword = UserPassword
                }
            });

            

            return new VerifySubscriptionResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = "success",
                Object = new BehPardakhtVerifyResult { ResCode = result.Body.@return}
            };









        }

        private void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
           delegate (
               Object sender1,
               X509Certificate certificate,
               X509Chain chain,
               SslPolicyErrors sslPolicyErrors)
           {
               return true;
           };
        }
    }
}
