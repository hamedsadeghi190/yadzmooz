using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class SubCategory : BaseEntity
    {
        public string Title{ get; set; }

        public string Description{ get; set; }

        public string Icon{ get; set; }

        public List<ShortChallenge> Challenges{ get; set; }

        public Guid CategoryId { get; set; }
        public int Piority { get; set; }
    }

    public class ShortSubCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }

    }
}


