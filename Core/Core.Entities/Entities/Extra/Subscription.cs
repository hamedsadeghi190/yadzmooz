using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Subscription : BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public int NumberOfDevice{ get; set; }
        public int DiscountPercent{ get; set; }
        public int Price{ get; set; }
        public int ExpireMonths{ get; set; }
    }
    public class ShortSubscription
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int DiscountPercent { get; set; }
        public int Status { get; set; }
    }

    public class UserSubscription
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int DiscountPercent { get; set; }
        public int Status { get; set; }
        public long ExpiryDate{ get; set; }
    }

}


