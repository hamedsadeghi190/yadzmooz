using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class CheckPoint : BaseEntity
    {
        public string Title{ get; set; }

        public string Description{ get; set; }

        public ShortFile File{ get; set; }


        public List<ShortCourse> Cources { get; set; }
        public List<Subject> Subjects { get; set; }
    }

    public class ShortCheckPoint
    {
        public Guid Id { get; set; }

    }
}


