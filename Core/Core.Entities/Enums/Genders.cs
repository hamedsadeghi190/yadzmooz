using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum Genders
    {
        [Display(Description = "زن")]
        Female = 1,
        [Display(Description = "مرد")]
        Male = 2,
        [Display(Description = "هر دو")]
        Both = 3
    }
}
