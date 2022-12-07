using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.BillPay.Models
{
    public class Collection
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class FinalResponse
    {
        public string Id { get; set; }
        public string Paid { get; set; }
        public string Paid_At { get; set; }
        public string X_Signiture { get; set; }
        public double Amount { get; set; }
    }
    public class Response
    {
        public string id { get; set; }
        public string collection_id { get; set; }
        public bool paid { get; set; }
        public string state { get; set; }
        public int amount { get; set; }
        public int paid_amount { get; set; }
        public string due_at { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string reference_1_label { get; set; }
        public string reference_1 { get; set; }
        public string reference_2_label { get; set; }
        public string reference_2 { get; set; }
        public string redirect_url { get; set; }
        public string callback_url { get; set; }
        public string description { get; set; }

    }
}
