using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class ArrangeSubCategoryDto
    {
        public List<ArrangeSubCategoryIntryObject> Intry { get; set; }

    }

    public class ArrangeSubCategoryResultDto : BaseApiResult
    {

    }


    public class ArrangeSubCategoryIntryObject
    {
        public Guid Id{ get; set; }
        public int Piority{ get; set; }
        public string Name{ get; set; }
    }
}
