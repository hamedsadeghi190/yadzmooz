using Core.ApplicationServices;
using Core.Entities.Dto;
using Core.Entities.Mongo.Enums;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class ChallengeController : SimpleController
    {
        private readonly IAddChallenge addChallenge;
        private readonly IPassChallenge passChallenge;
        private readonly IListChallenge listChallenge;
        private readonly IReadExels readExels;
        private readonly IAddListChallenge addListChallenge;
        private readonly IListWord listWord;
        private readonly IGenerateChallenge generateChallenge;
        private readonly IChangeWordStatus changeWordStatus;
        private readonly IDeleteChallenge deleteChallenge;
        private readonly IEditChallenge editChallenge;
        private readonly IGetByIdChallenge getByIdChallenge;

        public ChallengeController(

           IAddChallenge addChallenge,
           IPassChallenge passChallenge,
           IListChallenge listChallenge,
           IDeleteChallenge deleteChallenge,
           IEditChallenge editChallenge,
           IGetByIdChallenge getByIdChallenge,
           IReadExels readExels,
           IAddListChallenge addListChallenge,
           IListWord listWord,
           IGenerateChallenge generateChallenge,
           IChangeWordStatus changeWordStatus

            )
        {
            this.addChallenge = addChallenge;
            this.passChallenge = passChallenge;
            this.listChallenge = listChallenge;
            this.deleteChallenge = deleteChallenge;
            this.editChallenge = editChallenge;
            this.getByIdChallenge = getByIdChallenge;
            this.readExels = readExels;
            this.addListChallenge = addListChallenge;
            this.listWord = listWord;
            this.generateChallenge = generateChallenge;
            this.changeWordStatus = changeWordStatus;
        }

        [HttpPost]
        public ActionResult<AddChallengeResultDto> Create([FromBody] AddChallengeDto dto)
        {
            return addChallenge.Execute(dto);
        }

        [HttpPost]
        public ActionResult<AddListChallengeResultDto> MultiCreate([FromBody] AddListChallengeDto dto)
        {
            return addListChallenge.Execute(dto);
        }


        [HttpPost]
        public ActionResult<PassChallengeResultDto> PassChallenge([FromBody] PassChallengeDto dto)
        {
            return passChallenge.Execute(dto);
        }

        [HttpGet]
        public ActionResult Generate()
        {


            while (true)
            {
                var words = listWord.GetForChallenge(new ListWordDto { Status = WordStatus.Pending.ToInt() }).Object;

                if (words.Count == 0)
                {
                    break;
                }

                foreach (var item in words)
                {

                    var changeWordStatusres = new ChangeWordStatusResultDto();

                    try
                    {
                        generateChallenge.Execute(item);
                        changeWordStatusres = changeWordStatus.Execute(new ChangeWordStatusDto { Id = item.Id, Status = WordStatus.Created.ToInt() });

                    }
                    catch (Exception e)
                    {
                        changeWordStatusres = changeWordStatus.Execute(new ChangeWordStatusDto { Id = item.Id, Status = WordStatus.Failed.ToInt() });
                        Console.WriteLine(e);

                    }


                }



            }



            return Content("creating challenge completed");


        }

        [HttpGet]
        public ActionResult<ListChallengeResultDto> List([FromQuery] ListChallengeDto dto)
        {
            return listChallenge.Execute(dto);
        }

        [HttpGet]
        public ActionResult<GetByIdChallengeResultDto> GetById([FromQuery] GetByIdChallengeDto dto)
        {
            return getByIdChallenge.Execute(dto);
        }

        [HttpPut]
        public ActionResult<EditChallengeResultDto> Edit([FromBody] EditChallengeDto dto)
        {
            return editChallenge.Execute(dto);
        }
        [HttpDelete]
        public ActionResult<DeleteChallengeResultDto> Delete([FromQuery] DeleteChallengeDto dto)
        {
            return deleteChallenge.Execute(dto);
        }
        [HttpGet]
        public ActionResult readExcel()
        {
            readExels.Execute();
            return Content("read");
        }




    }
}
