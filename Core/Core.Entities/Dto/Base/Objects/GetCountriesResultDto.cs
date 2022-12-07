
using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class GetCountriesResultDto : BaseApiResult
    {
        public List<CountryDto> Object { get; set; }

    }
}
