using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public int NumberOfDevice { get; set; }
        public int DiscountPercent { get; set; }
        public int Price { get; set; }
        public int ExpireMonths { get; set; }

    }


}
