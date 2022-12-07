using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Transactions : BaseEntity
    {
        public string Description { get; set; }
        public int DiscountPercent{ get; set; }
        public long Amount { get; set; }
        public long Price{ get; set; }
        public long OrderId{ get; set; }
        public int Status{ get; set; }
        public Guid SubscriptionId{ get; set; }
        public Guid UserId{ get; set; }
    }

    //public class ShortSubscription
    //{
    //    public Guid Id { get; set; }
    //    public string Icon { get; set; }
    //    public string Title { get; set; }
    //    public int Price { get; set; }
    //    public int DiscountPercent { get; set; }
    //}

}


