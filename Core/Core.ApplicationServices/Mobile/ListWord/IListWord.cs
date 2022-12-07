using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IListWord : IApplicationService
    {
        ListWordResultDto Execute(ListWordDto dto);
        ListWordResultDto GetForChallenge(ListWordDto listWordDto);
    }
}


