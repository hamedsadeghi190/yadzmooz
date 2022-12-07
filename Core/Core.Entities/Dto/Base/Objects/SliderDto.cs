
using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class SliderDto
    {
        public string Address{ get; set; }
        public Guid Id { get;  set; }
        public string Destination { get; internal set; }
        public string Link { get; internal set; }
    }
}
