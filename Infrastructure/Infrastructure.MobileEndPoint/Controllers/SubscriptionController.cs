using Core.ApplicationServices;
using Core.Entities.Dto;
using Core.Entities.Mongo.Enums;
using Infrastructure.EndPoint.Controllers;
using Infrastructure.MobileEndpoint.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class SubscriptionController : Controller
    {
        private readonly IAddSubscription addSubscription;
        private readonly IEditSubscription editSubscription;
        private readonly IDeleteSubscription deleteSubscription;
        private readonly IBuySubscription buySubscription;
        private readonly IGetByIdSubscription getByIdSubscription;
        private readonly IAddTransactionToUser addTransactionToUser;
        private readonly IListSubscription listSubscription;
        private readonly IVerifySubscription verifySubscription;

        public SubscriptionController(
            IAddSubscription addSubscription,
            IEditSubscription editSubscription,
            IDeleteSubscription deleteSubscription,
            IBuySubscription buySubscription,
            IGetByIdSubscription getByIdSubscription,
            IAddTransactionToUser addTransactionToUser,
            IListSubscription listSubscription,
            IVerifySubscription verifySubscription

            )
        {
            this.addSubscription = addSubscription;
            this.editSubscription = editSubscription;
            this.deleteSubscription = deleteSubscription;
            this.buySubscription = buySubscription;
            this.getByIdSubscription = getByIdSubscription;
            this.addTransactionToUser = addTransactionToUser;
            this.listSubscription = listSubscription;
            this.verifySubscription = verifySubscription;
        }

        [HttpPost]
        public ActionResult<AddSubscriptionResultDto> Create([FromBody] AddSubscriptionDto dto)
        {
            return addSubscription.Execute(dto);
        }

        [HttpGet]
        public ActionResult<ListSubscriptionResultDto> List([FromQuery] ListSubscriptionDto dto)
        {
            return listSubscription.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetByIdSubscriptionResultDto> GetById([FromQuery] GetByIdSubscriptionDto dto)
        {
            return getByIdSubscription.Execute(dto);
        }


        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public ActionResult<BuySubscriptionResultDto> CallBack([FromForm] CallBackDto dto)
        {

            ViewBag.ResCode = dto.ResCode;
            ViewBag.SaleReferenceId = dto.SaleReferenceId;
            ViewBag.SaleOrderId = dto.SaleOrderId;
            ViewBag.FinalAmount = dto.FinalAmount;


            var verifyresult = verifySubscription.Execute(new VerifySubscriptionDto { orderId = dto.SaleOrderId, saleOrderId = dto.SaleOrderId, saleReferenceId = dto.SaleReferenceId });

            if (long.Parse(verifyresult.Object.ResCode )== 0 || dto.ResCode ==0)
            {
                ViewBag.PayStatus = true;
                var res = addTransactionToUser.Execute(new AddTransactionToUserDto { OrderId = dto.SaleOrderId, Status = 2 });
            }
            else
            {
                ViewBag.PayStatus = false;
                var res = addTransactionToUser.Execute(new AddTransactionToUserDto { OrderId = dto.SaleOrderId, Status = 3 });

            }


            return View();
        }

        [HttpGet]
        public ActionResult<BuySubscriptionResultDto> Buy([FromQuery] BuySubscriptionDto dto)
        {
            var res = buySubscription.Execute(dto);
            ViewBag.RefId = res.Object.RefId;
            ViewBag.MobileNo = res.Object.MobileNo;
            ViewBag.Amount = res.Object.Amount;
            ViewBag.Title = res.Object.Title;
            return View();
        }

        //[HttpGet]
        //public ActionResult<BuySubscriptionResultDto> Verify([FromQuery] BuySubscriptionDto dto)
        //{

        //    var res = buySubscription.Execute(dto);


        //    ViewBag.RefId = res.Object.RefId;
        //    return View();
        //}



        [HttpPut]
        public ActionResult<EditSubscriptionResultDto> Edit([FromBody] EditSubscriptionDto dto)
        {
            return editSubscription.Execute(dto);
        }
        [HttpDelete]
        public ActionResult<DeleteSubscriptionResultDto> Delete([FromQuery] DeleteSubscriptionDto dto)
        {
            return deleteSubscription.Execute(dto);
        }




    }
}
