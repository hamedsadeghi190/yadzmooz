using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ServiceApi.Models
{


    public class Object
    {
        public string title { get; set; }
        public string location { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public string id { get; set; }
        public int createdAt { get; set; }
    }

    public class Requests : BaseApiResult
    {
        public List<Object> @object { get; set; }



    }

    public class BaseApiResult
    {
        public int code { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }
    }

    public class ChangeStausObject
    {
        public Guid orderForPrintId { get; set; }
        public int status { get; set; }
    }

    public class LastOrderId
    {
        public string OrderId{ get; set; }
    }

}
