using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetUserSubscriptionsDto
    {
        public Guid UserId { get; set; }
    }
 

    public class GetUserSubscriptionsResultDto : BaseApiResult
    {
        public List<UserSubscription> Object { get; set; }
    }

}
