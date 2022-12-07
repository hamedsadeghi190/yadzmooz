using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUsersByPageDto : BaseByPageDto
    {

    }
    public class GetUsersByPageResultDto 
    {
        public List<UserDto> Object { get; set; }
    }
}
