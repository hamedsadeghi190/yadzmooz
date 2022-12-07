using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShortProvince> Provinces { get; set; }
    }
}


