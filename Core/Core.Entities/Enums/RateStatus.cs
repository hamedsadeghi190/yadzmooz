using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum RateStatus
    {
        [Display(Description = "در انتظار تایید")]
        Wating = 1,
        [Display(Description = "تایید شده")]
        Accepted = 2,
        [Display(Description = "تایید نشده")]
        NotApproved = 3,
    }
}
