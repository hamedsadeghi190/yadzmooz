using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class BuySubscriptionDto
    {
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
    }

    public class CallBackDto
    {
        public long ResCode { get; set; }
        public string RefId{ get; set; }
        public long SaleOrderId { get; set; }
        public long FinalAmount { get; set; }
        public  long SaleReferenceId { get; set; }
    }

    public class BuySubscriptionResultDto : BaseApiResult
    {
        public BehPardakhtResult Object { get; set; }
    }


    public class VerifySubscriptionDto
    {
        public long orderId  { get; set; }
        public long saleOrderId  { get; set; }
        public long saleReferenceId  { get; set; }
    }

    public class VerifySubscriptionResultDto : BaseApiResult
    {
        public BehPardakhtVerifyResult Object { get; set; }
    }


    public class BehPardakhtResult
    {
        public string RefId{ get; set; }
        public string MobileNo { get; set; }
        public long Amount { get; set; }
        public string Title { get; set; }
    }

    public class BehPardakhtVerifyResult
    {
        public string ResCode { get; set; }
 
    }

    public class BuyObject 
    {
        public long terminalId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public long orderId { get; set; }
        public long amount { get; set; }
        public string localDate { get; set; }
        public string localTime { get; set; }
        public string additionalData { get; set; }
        public string callBackUrl { get; set; }
        public long payerId { get; set; }
    }

    public class Buy
    {
    
    }
}
