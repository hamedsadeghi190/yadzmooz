using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum FileTypes
    {
        [Display(Description = "عکس")]
        Image = 1,
        [Display(Description = "صدا")]
        Sound = 2,
        [Display(Description = "ویدیو")]
        Video = 3,
        [Display(Description = "زیپ")]
        Zip = 4,

    }
}
