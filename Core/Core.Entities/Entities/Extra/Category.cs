using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Category : BaseEntity
    {
        public string Title{ get; set; }

        public string Description{ get; set; }

        public string Icon{ get; set; }

        public Guid LanguageId { get; set; }

        public List<ShortSubCategory> SubCategories { get; set; }
    }

    public class ShortCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }

    }
}


