using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListSubscriptionDto 
    {

    }

    public class ListSubscriptionResultDto : BaseApiResult
    {
        public List<SubscriptionDto> Object { get; set; }
    }
}
