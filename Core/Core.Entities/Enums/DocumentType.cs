using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum DocumentType
    {
        [Display(Description = "تصویر")]
        Image = 1,
        [Display(Description = "فیلم")]
        Video = 2,
        [Display(Description = "سند")]
        Document = 3

    }
}
