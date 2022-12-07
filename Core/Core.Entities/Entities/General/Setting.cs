
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Mongo
{
    public class Setting 
    {
        public Guid Id{ get; set; }
        public double DeliveryPricePerKM{ get; set; }
        public int CommitionPricePercent{ get; set; }
        public string AdminPrinterName{ get; set; }
        public string CashierPrinterName{ get; set; }
        public int OpeningTime{ get; set; }
        public int ClosingTime{ get; set; }
        public bool BillPlzPayForCustomer{ get; set; }
    }    
}


