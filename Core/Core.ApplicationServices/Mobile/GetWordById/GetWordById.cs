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
    public class GetWordById : IGetWordById
    {
        private readonly IUnitOfWork unit;

        public GetWordById
            (
            IUnitOfWork unit
            )
        {
            this.unit = unit;
        }


        public GetWordByIdResultDto Execute(GetWordByIdDto dto)
        {
            return new GetWordByIdResultDto 
            {
                Code = 0 , 
                IsSuccess = true,
                Message = Messages.OK,
                Object = unit.Words.GetById(dto.Id)
            };
        }
    }
}
