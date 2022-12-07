using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class ActivationCodeController : SimpleController
    {
        private readonly ISendActivationCode sendActivationCode;
        private readonly ICheckActivationCode checkActivationCode;

        public ActivationCodeController(ISendActivationCode sendActivationCode, ICheckActivationCode checkActivationCode)
        {
            this.sendActivationCode = sendActivationCode;
            this.checkActivationCode = checkActivationCode;
        }

        [HttpPost]
        public ActionResult<SendActivationCodeResultDto> Send([FromBody] SendActivationCodeDto dto)
        {
            return sendActivationCode.Execute(dto);
        }

        [HttpPost]
        public ActionResult<CheckActivationCodeResultDto> Check([FromBody] CheckActivationCodeDto dto)
        {
            return checkActivationCode.Execute(dto);
        }

        //[HttpPost]
        //public ActionResult<SendActivationCodeResultDto> Send([FromBody] SendActivationCodeDto dto)
        //{
        //    return sendActivationCode.Execute(dto);
        //}
        ////[HttpPost]
        ////public ActionResult<SendActiveCodeResultDto> AddFoodCategory([FromBody] AddFoodCategoryDto dto)
        ////{
        ////    return addFoodCategory.Execute(dto);
        ////}

    }
}
