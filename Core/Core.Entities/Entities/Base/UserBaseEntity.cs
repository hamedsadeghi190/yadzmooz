using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mongo
{
    public abstract class UserBaseEntity
    {
        public Guid Id { get; set; }
        public long CreatedAt { get; set; }
    }
}
