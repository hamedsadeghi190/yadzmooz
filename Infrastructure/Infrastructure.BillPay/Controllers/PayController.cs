using Core.ApplicationServices;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using Infrastructure.BillPay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BillPay.Controllers
{
    public class PayController : Controller
    {
        private readonly ILogger<PayController> _logger;
        private readonly IChargeWallet chargeWallet;
        private readonly IUnitOfWork unit;

        public PayController(ILogger<PayController> logger, IChargeWallet chargeWallet,IUnitOfWork unit)
        {
            _logger = logger;
            this.chargeWallet = chargeWallet;
            this.unit = unit;
        }

        string api_key = "cd94af88-3ad1-49ba-849a-bcc1aa6cd668";


        public IActionResult Result()
        {


            var res = new FinalResponse
            {
                Id = HttpContext.Request.Query["billplz[id]"],
                Paid = HttpContext.Request.Query["billplz[paid]"],
                Paid_At = HttpContext.Request.Query["billplz[paid_at]"],
                X_Signiture = HttpContext.Request.Query["billplz[x_signature]"],
                Amount = 0
            };

        
                var client = new RestClient($"https://www.billplz.com/api/v3/bills/{res.Id}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);


                request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(api_key)) + "Og==");
                IRestResponse response = client.Execute(request);
                var bill = new Bill();
                bill = JsonConvert.DeserializeObject<Bill>(response.Content);



                var doubleAmount = Convert.ToDouble(bill.Amount);
            
                
                if (bill.Paid)
                {
                    //var respons = chargeWallet.Execute(new ChargeWalletDto { UserId = Guid.Parse(bill.Reference_1), Amount = bill.Amount / 100 });
                    unit.Wallets.ChargeWalletAmount(new ChargeWalletDto { UserId = Guid.Parse(bill.Reference_1), Amount = doubleAmount / 100 });

                }

                res.Amount = doubleAmount / 100;

                





                return View(res);


        }

        







    }
}
