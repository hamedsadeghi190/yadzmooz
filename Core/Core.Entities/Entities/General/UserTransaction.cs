using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities.Mongo
{
    public class UserTransaction : BaseEntity
    {        
        public TransactionCategory TransactionCategory { get; set; }
        public string Authority{ get; set; }
        public string RefId{ get; set; }
        public bool IsSuccessful{ get; set; }
        public int Amount { get; set; }
        public string Description{ get; set; }
    }
}
