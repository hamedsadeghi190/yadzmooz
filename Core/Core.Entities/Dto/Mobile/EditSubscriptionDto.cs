using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class EditSubscriptionDto
    {
        public Guid Id{ get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public int NumberOfDevice { get; set; }
        public int DiscountPercent { get; set; }
        public int Price { get; set; }
        public int ExpireMonths { get; set; }
    }

    public class EditSubscriptionResultDto : BaseApiResult
    {

    }
}
