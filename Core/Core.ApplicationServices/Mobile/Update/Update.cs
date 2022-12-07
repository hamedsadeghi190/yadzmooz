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
    public class Update : IUpdate
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public Update
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }



    

        public void Add(AddCheckUpdateDto dto)
        {
            unit.Updates.AddUpdate(dto);
        }

        public Entities.Dto.CheckUpdateResultDto Execute(CheckUpdateDto dto)
        {
            return unit.Updates.CheckUpdate();
        }

    }
}
