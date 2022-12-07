using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.ServiceApi.Models
{
    public enum CashAprovalStatus
    {
        [Display(Description = "اردر کش نیست")]
        OrderIsNotCash = 0,
        [Display(Description = "در انتظار")]
        Pending = 1,
        [Display(Description = "تایید شده")]
        Aproved = 2
        
    }
}
