using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class EditWordDto
    {
        public Guid Id{ get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Meaning { get; set; }
        public string Word { get; set; }
        public string VoiceFile { get; set; }
        public string ImageFile { get; set; }

    }


  

    public class EditWordResultDto : BaseApiResult
    {

    }


}
