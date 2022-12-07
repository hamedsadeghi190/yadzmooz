using System;

namespace Core.Entities.Dto
{
    public class ChangeUserCityDto
    {
        public Guid UserId { get; set; }
        public int CityId { get; set; }

    }
}
