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
    public class EditChallenge : IEditChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditChallenge
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditChallengeResultDto Execute(EditChallengeDto dto)
        {

            var challenge = unit.Challenges.GetById(dto.Id);
            challenge.Options = dto.Options;
            challenge.Meanings = dto.Meanings;
            challenge.Type = dto.Type;
            challenge.CorrectAnswer = dto.CorrectAnswer;
            challenge.Word = dto.Word;
            challenge.Title = dto.Title;

            unit.Challenges.Replace(challenge);


            //:todo when short challenge changed you must edited this 



            return new EditChallengeResultDto 
            {
                Code  = 0,
                IsSuccess = true,
                Message = Messages.OK
                 
            };
        }
    }
}
