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
    public class ChangeWordStatus : IChangeWordStatus
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ChangeWordStatus
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ChangeWordStatusResultDto Execute(ChangeWordStatusDto dto)
        {


            var word = unit.Words.GetById(dto.Id);

            word.Status = dto.Status;

            

            unit.Words.Replace(word);


            return new ChangeWordStatusResultDto 
            {
                Code = 0 ,
                IsSuccess = true,
                Message = Messages.OK
            };

        }
    }
}
