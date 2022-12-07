
using System;
using System.Collections.Generic;

namespace Core.Entities.Mongo.Dto
{
    public class BaseApiResult
    {
        public int Code{ get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class BaseApiPageResult : BaseApiResult
    {
        public PageDto Page { get; set; }
    }
    public class BaseApiMongoPageResult : BaseApiResult
    {
        public long? TotalCount { get; set; }
        public int? BlockSize{ get; set; }
    }

    public class ApiResultWithObject : BaseApiResult
    {
        public object Object { get; set; }
    }
    public class PageDto
    {
        public int Total { get; set; }
        public int CurrentCount { get; set; }
        public int PageNo { get; set; }
    }
    
    public class FixedIntDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class FixedIntResultDto : BaseApiResult
    {
        public List<FixedIntDto> Object { get; set; }
    }
    public class FixedGuidResultDto : BaseApiResult
    {
        public List<FixedGuidDto> Object { get; set; }
    }
    public class FixedGuidDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }


}
