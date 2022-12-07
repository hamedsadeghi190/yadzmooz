using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class WordController : SimpleController
    {
        private readonly IAddListWord addListWord;
        private readonly IListWord listWord;
        private readonly IEditWord editWord;
        private readonly IDeleteWord deleteWord;
        private readonly IGetWordById getWordById;

        public WordController(


           IAddListWord addListWord,
           IListWord listWord,
           IEditWord editWord,
           IDeleteWord deleteWord,
           IGetWordById getWordById


            )
        {
            this.addListWord = addListWord;
            this.listWord = listWord;
            this.editWord = editWord;
            this.deleteWord = deleteWord;
            this.getWordById = getWordById;
        }

        [HttpGet]
        public ActionResult<ListWordResultDto> List([FromQuery] ListWordDto dto)
        {
            return listWord.Execute(dto);
        }

        [HttpPost]
        public ActionResult<AddListWordResultDto> MultiCreate([FromBody] AddListWordDto dto)
        {
            return addListWord.Execute(dto);
        }


        [HttpPut]
        public ActionResult<EditWordResultDto> Edit([FromBody] EditWordDto dto)
        {
            return editWord.Execute(dto);
        }

        [HttpDelete]
        public ActionResult<DeleteWordResultDto> Delete([FromQuery] DeleteWordDto dto)
        {
            return deleteWord.Execute(dto);
        }

        [HttpGet]
        public ActionResult<GetWordByIdResultDto> GetById([FromQuery] GetWordByIdDto dto)
        {
            return getWordById.Execute(dto);
        }







    }
}
