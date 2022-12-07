using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.ServiceApi.Models
{
    public enum OrderPaymentType
    {
        [Display(Description = "نقد")]
        Cash = 1,
        [Display(Description = "پرداخت از کیف پول")]
        Online = 2
        
    }
}
