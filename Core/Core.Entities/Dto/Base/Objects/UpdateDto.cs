
using System;
using System.Collections.Generic;
using Utility.Tools.Auth;

namespace Core.Entities.Mongo.Dto
{
    public class UpdateDto : BaseApiResult
    {
        public Update Object { get; set; }
    }
}
