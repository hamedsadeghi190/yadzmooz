using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mongo
{
    public class Notification : BaseEntity
    {
        
        public string Description { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int RoleId { get; set; }
    }
}
