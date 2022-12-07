using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IUpdateRepository
    {
        CheckUpdateResultDto CheckUpdate();
        void AddUpdate(AddCheckUpdateDto dto);
    }
}
