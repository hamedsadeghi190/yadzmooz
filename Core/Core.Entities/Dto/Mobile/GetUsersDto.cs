using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetUsersDto
    {
    }
 

    public class GetUsersResultDto : BaseApiResult
    {
        public List<UserLoginDto> Object { get; set; }
    }

}
