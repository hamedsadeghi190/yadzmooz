using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetByIdSubscriptionDto
    {
        public Guid Id { get; set; }
    }

    public class GetByIdSubscriptionResultDto : BaseApiResult
    {
        public Subscription Object{ get; set; }
    }
}
