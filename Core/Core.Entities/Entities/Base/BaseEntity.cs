using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mongo
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public long CreatedAt { get; set; }
    }
}
