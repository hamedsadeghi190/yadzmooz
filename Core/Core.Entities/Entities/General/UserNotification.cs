using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mongo
{
    public class UserNotification : BaseEntity
    {
        public Notification Notification{ get; set; }
    }
}
