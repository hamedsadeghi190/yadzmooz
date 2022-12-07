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
    public class ListFileRequest : IListFileRequest
    {
        private readonly IUnitOfWork unit;

        public ListFileRequest
            (
            IUnitOfWork unit
            )
        {
            this.unit = unit;
        }


        public ListFileRequestResultDto Execute(ListFileRequestDto dto)
        {
            return new ListFileRequestResultDto 
            {
                Code = 0 , 
                IsSuccess = true,
                Message = Messages.OK,
                Object = unit.FileRequest.GetAll()
            };
        }
    }
}
