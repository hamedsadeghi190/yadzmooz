using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Mongo.Enums
{
    public enum TransactionStatus
    {
        Success = 2,
        Failed = 3,
        Pending = 1,
    }
}

