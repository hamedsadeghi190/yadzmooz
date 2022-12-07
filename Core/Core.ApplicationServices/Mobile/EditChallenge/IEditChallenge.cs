using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IEditChallenge : IApplicationService
    {
        EditChallengeResultDto Execute(EditChallengeDto dto);
    }
}


