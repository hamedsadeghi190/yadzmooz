using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class AddTransactionToUserDto
    {
        public long OrderId { get; set; }
        public int Status{ get; set; }
    }

    public class AddTransactionToUserResultDto : BaseApiResult
    {

    }
}
