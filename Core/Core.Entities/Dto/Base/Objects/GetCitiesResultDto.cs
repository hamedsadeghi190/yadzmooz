
using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class GetCitiesResultDto : BaseApiResult
    {
        public List<CityDto> Object { get; set; }

    }
}
