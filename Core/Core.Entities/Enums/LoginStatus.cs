using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum LoginStatus
    {
        [Display(Description = "لاگین است")]
        LogedIn = 1,
        [Display(Description = "لاگین نیست")]
        LogedOut = 2
        
    }
}
