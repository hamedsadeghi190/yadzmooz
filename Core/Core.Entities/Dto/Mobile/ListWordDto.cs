using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ListWordDto 
    {
        public int? PageNo { get; set; }
        public int? PageCount { get; set; }
        public int Status { get; set; }
        public Guid LanguageId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
    }

    public class ListWordResultDto : BaseApiMongoPageResult
    {
        public List<Words> Object { get; set; }
    }

    public class ListWordObejct 
    {
        public List<Words> Object { get; set; }
        public long? Total { get; set; }
    }



}