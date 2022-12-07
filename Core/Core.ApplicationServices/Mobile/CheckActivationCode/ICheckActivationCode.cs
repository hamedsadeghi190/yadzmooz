using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface ICheckActivationCode : IApplicationService
    {
        CheckActivationCodeResultDto Execute(CheckActivationCodeDto dto);
    }
}
