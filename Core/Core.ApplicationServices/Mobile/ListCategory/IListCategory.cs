using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IListCategory : IApplicationService
    {
        ListCategoryResultDto Execute(ListCategoryDto dto);
        ListCategoryMobileResultDto MobileExecute(ListCategoryDto dto);
    }
}


