using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IGenerateChallenge : IApplicationService
    {
        void Execute(Words dto);
    }
}


