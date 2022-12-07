using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mongo.Dto.Countries
{
    public class CountryJson
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public List<State> states { get; set; }
    }

    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state_code { get; set; }
        public List<City> cities { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
