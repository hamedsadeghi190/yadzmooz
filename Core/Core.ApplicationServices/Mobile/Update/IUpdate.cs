using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IUpdate : IApplicationService
    {
        CheckUpdateResultDto Execute(CheckUpdateDto dto);
        void Add(AddCheckUpdateDto dto);
    }
}


