using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Lesson : BaseEntity
    {
        public string Title{ get; set; }
        public string Description{ get; set; }
        public List<ShortChallenge> Challenges { get; set; }
    }

    public class ShortLesson 
    {
        public Guid Id { get; set; }

    }
}


