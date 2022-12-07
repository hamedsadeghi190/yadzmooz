using System;

namespace Core.Entities.Mongo.Dto
{
    public class GetProvincesDto
    {
        public int? CountryId { get; set; }
        public string KeyWord { get; set; }

    }
}
