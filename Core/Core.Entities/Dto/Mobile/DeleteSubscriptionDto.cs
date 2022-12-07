using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class DeleteSubscriptionDto
    {
        public Guid Id { get; set; }
    }

    public class DeleteSubscriptionResultDto : BaseApiResult
    {

    }
}
