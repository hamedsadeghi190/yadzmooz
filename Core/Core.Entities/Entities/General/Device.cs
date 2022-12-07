using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Device: BaseEntity
    {
        public string PushId { get; set; }
        public int RoleId{ get; set; }
        public Guid UserId{ get; set; }
        public Guid? StoreId{ get; set; }


    }


}


