using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
    public class ShortCity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}


