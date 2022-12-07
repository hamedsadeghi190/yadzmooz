using System;

namespace Core.Entities.Mongo.Dto
{
    public class GetCitiesDto
    {
        public int? ProvienceId { get; set; }
        public string KeyWord { get; set; }

    }
}
