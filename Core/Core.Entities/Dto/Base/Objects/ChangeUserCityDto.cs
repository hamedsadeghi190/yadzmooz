using System;

namespace Core.Entities.Mongo.Dto
{
    public class ChangeUserCityDto
    {
        public Guid UserId { get; set; }
        public int CityId { get; set; }

    }
}
