using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class AddCityDto
    {
        public string Name { get; set; }
        public int ProvienceId{ get; set; }
    }
}
