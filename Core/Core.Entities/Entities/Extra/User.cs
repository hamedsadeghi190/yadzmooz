using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class User : BaseEntity
    {
        public string Mobile{ get; set; }
        public string UserName{ get; set; }
        public string firstName{ get; set; }
        public string LastName{ get; set; }
        public int Status{ get; set; }
        public long SubscriptionExpireDate{ get; set; }
        public int? Age{ get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        //public List<ShortLanguage> Languages{ get; set; }
        //public List<ShortCheckPoint> CheckPoints{ get; set; }
        //public Dictionary<Course, int> Courses { get; set; }
        //public List<ShortLesson> Lessons{ get; set; }
        public List<UserChallenge> Challenges{ get; set; }
        public List<UserSubscription> Subscriptions{ get; set; }
        public UserChallenge LastSubCategory { get; set; }
    
    }

    public class ShortUser 
    {
        public Guid Id{ get; set; }
    }
}


