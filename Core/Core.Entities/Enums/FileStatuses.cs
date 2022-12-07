using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum FileStatuses
    {
        [Display(Description = "در حال انتظار")]
        Pending = 1,
        [Display(Description = "تایید شده")]
        Accepted = 2,
        [Display(Description = "رد شده")]
        Rejected = 3,

    }
}
