using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddChallenge : IAddChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public AddChallenge
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public Entities.Dto.AddChallengeResultDto Execute(AddChallengeDto dto)
        {

            var challenge = new Challenge
            {
                CreatedAt = Agent.Now,
                CorrectAnswer = dto.CorrectAnswer,
                Meanings = dto.Meanings,
                Id = new Guid(),
                Options = dto.Options,
                Type = dto.Type,
                SubCategoryId = dto.SubCategoryId,
                Word = dto.Word,
                Title = dto.Title,
            };




            unit.Challenges.Insert(challenge);
            unit.SubCategories.AddChallengeToSubCategory(challenge.Id,challenge.SubCategoryId);


            return new AddChallengeResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };
        }
    }
}
