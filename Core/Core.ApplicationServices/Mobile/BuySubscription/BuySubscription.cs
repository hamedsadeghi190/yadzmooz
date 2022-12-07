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
using Core.Entities.Mongo.Enums;

namespace Core.ApplicationServices
{
    public class BuySubscription : IBuySubscription
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;
        private readonly IPaymentGateway paymentGateway;

        public BuySubscription
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


        public BuySubscriptionResultDto Execute(BuySubscriptionDto dto)
        {

            var sub = unit.Subscriptions.GetById(dto.SubscriptionId);
            var user = unit.Users.GetById(dto.UserId);







            string PgwSite = @"https://bpm.shaparak.ir/pgwchannel/services/pgw?wsdl";
            string CallBackUrl = @"https://api.yaadamooz.com/Subscription/CallBack";
            long TerminalId = 5799270;
            string UserName = "Parman123";
            string UserPassword = "55180195";

            var request = new bpPayRequestBody
            {
                terminalId = TerminalId,
                userName = UserName,
                userPassword = UserPassword,
                orderId = DateTime.Now.Millisecond,
                amount = (sub.Price - ((sub.Price  * sub.DiscountPercent) / 100 )) * 10,
                localDate = DateTime.Now.ToString("yyyyMMdd"),
                localTime = DateTime.Now.ToString("HHmmss"),
                additionalData = user.Id.ToString(),
                callBackUrl = CallBackUrl
            };


            unit.Transactions.Insert(new Transactions
            {
                Amount = sub.Price,
                Price = request.amount / 10,
                CreatedAt = Agent.Now,
                Description = "",
                DiscountPercent = sub.DiscountPercent,
                OrderId = request.orderId,
                Status = TransactionStatus.Pending.ToInt(),
                SubscriptionId = dto.SubscriptionId,
                UserId = dto.UserId
            });

            var result = paymentGateway.bpPayRequest(new bpPayRequest
            {
               Body = request
            });

            var splitstr = result.Body.@return.Split(',');
            var refId = splitstr[1];
            return new BuySubscriptionResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = "success",
                Object = new BehPardakhtResult { RefId = refId , MobileNo = user.Mobile , Amount = request.amount,Title = sub.Title }
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
