using Core.Entities.Mongo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class File : BaseEntity
    {
        public string Location { get; set; }
        public int Size { get; set; }
        public int Duration { get; set; }
        public FileStatuses Status { get; set; }
        public FileTypes Type { get; set; }
    }
    public class ShortFile 
    {
        public Guid Id { get; set; }
        public string Location{ get; set; }
        public FileTypes Type { get; set; }
    }
}


