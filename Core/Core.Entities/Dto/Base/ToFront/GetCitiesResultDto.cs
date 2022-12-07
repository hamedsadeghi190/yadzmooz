
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetCitiesResultDto : BaseApiResult
    {
        public List<CityDto> Object { get; set; }
    }


}
