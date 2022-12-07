using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class GetUserByIdDto
    {
        public Guid Id { get; set; }
    }
 

    public class GetUserByIdResultDto : BaseApiResult
    {
        public UserLoginDto Object { get; set; }
    }

}
