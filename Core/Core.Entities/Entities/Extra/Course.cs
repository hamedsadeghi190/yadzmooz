using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ShortFile File { get; set; }
        public string Tips{ get; set; }
        public int Levels{ get; set; }
        public List<ShortLesson> Lessons{ get; set; }

    }

    public class ShortCourse 
    {
        public Guid Id { get; set; }

    }
}


