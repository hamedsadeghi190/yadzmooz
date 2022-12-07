using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class AddWordDto
    {
        public Guid? CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public string Meaning { get; set; }
        public string Word { get; set; }
        public string VoiceFile { get; set; }
        public string ImageFile { get; set; }
        public string SubCategoryTitle { get; set; }

    }


    public class AddListWordDto
    {
        public List<AddWordDto> Intry { get; set; }

    }

    public class AddListWordResultDto : BaseApiResult
    {

    }

    public class AddWordResultDto : BaseApiResult
    {

    }
}
