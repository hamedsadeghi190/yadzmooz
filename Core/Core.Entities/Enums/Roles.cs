 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum Roles
    {
        [Display(Description = "کاربر")]
        User = 1,
        [Display(Description = "ادمین")]
        Admin = 2, 
        [Display(Description = "رستوراندار")]
        StoreOwner = 3,
        [Display(Description = "گارسون")]
        Water = 4, 
        [Display(Description = "صندوقدار")]
        Cashier = 5,
        [Display(Description = "پیک")]
        Delivery = 6
    }
}
