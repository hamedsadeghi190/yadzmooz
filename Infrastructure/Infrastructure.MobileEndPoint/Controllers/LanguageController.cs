using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class LanguageController : SimpleController
    {
        private readonly IAddLanguage addLanguage;
        private readonly IEditLanguage editLanguage;
        private readonly IDeleteLanguage deleteLanguage;
        private readonly IGetByIdLanguage getByIdLanguage;
        private readonly IListLanguage listLanguage;

        public LanguageController(
            IAddLanguage addLanguage,
            IEditLanguage editLanguage,
            IDeleteLanguage deleteLanguage,
            IGetByIdLanguage getByIdLanguage,
            IListLanguage listLanguage 

            )
        {
            this.addLanguage = addLanguage;
            this.editLanguage = editLanguage;
            this.deleteLanguage = deleteLanguage;
            this.getByIdLanguage = getByIdLanguage;
            this.listLanguage = listLanguage;
        }

        [HttpPost]
        public ActionResult<AddLanguageResultDto> Create([FromBody] AddLanguageDto dto)
        {
            return addLanguage.Execute(dto);
        }

        [HttpGet]
        public ActionResult<ListLanguageResultDto> List([FromQuery] ListLanguageDto dto)
        {
            return listLanguage.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetByIdLanguageResultDto> GetById([FromQuery] GetByIdLanguageDto dto)
        {
            return getByIdLanguage.Execute(dto);
        }

        [HttpPut]
        public ActionResult<EditLanguageResultDto> Edit([FromBody] EditLanguageDto dto)
        {
            return editLanguage.Execute(dto);
        }
        [HttpDelete]
        public ActionResult<DeleteLanguageResultDto> Delete([FromQuery] DeleteLanguageDto dto)
        {
            return deleteLanguage.Execute(dto);
        }




    }
}
