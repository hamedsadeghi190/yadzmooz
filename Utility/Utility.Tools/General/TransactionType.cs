using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum TransactionType
    {
        [Display(Description = "پرداخت")]
        Pay= 1,
        [Display(Description = "دریافت")]
        Receive = 2,
        [Display(Description = "ارسال")]
        Send= 3,
        [Display(Description = "درگاه")]
        Gateway = 4,
        [Display(Description = "نقدی")]
        Cash = 5

    }
}
