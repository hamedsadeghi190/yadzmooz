using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
    public class ShortProvince
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShortCity> Cities { get; set; }


    }


}


