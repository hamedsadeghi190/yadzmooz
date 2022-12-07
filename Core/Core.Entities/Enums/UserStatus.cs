using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum UserStatus
    {
        [Display(Description = "غیر فعال")]
        Deactive = 0,
        [Display(Description = "فعال")]
        Active = 1,
        [Display(Description = "آنلاین")]
        Online = 2,
        [Display(Description = "آفلاین")]
        Offline = 3

    }
}
