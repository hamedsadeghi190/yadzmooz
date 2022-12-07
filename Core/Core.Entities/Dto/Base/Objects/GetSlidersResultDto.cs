
using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class GetSlidersResultDto : BaseApiResult
    {
        public List<SliderDto> Object { get; set; }

    }


}
