using Core.ApplicationServices;
using Core.Entities.Dto;
using Core.Entities.Mongo.Enums;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class UpdateController : SimpleController
    {
        private readonly IUpdate update;

        public UpdateController
            (
            IUpdate update
            )
        {
            this.update = update;
        }
        [HttpGet]
        public ActionResult<CheckUpdateResultDto> CheckUpdate([FromQuery] CheckUpdateDto dto)
        {
            return update.Execute(dto);
        }

        [HttpPost]
        public ActionResult<CheckUpdateResultDto> AddUpdate([FromBody] AddCheckUpdateDto dto)
        {
            update.Add(dto);
            return null;
        }

    }
}
