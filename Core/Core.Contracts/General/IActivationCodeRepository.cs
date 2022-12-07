using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IActivationCodeRepository
    {
        bool CheckExeed(string mobile);
        void Insert(ActivationCode activationCode);
        bool CheckActiveCode(CheckActivationCodeDto dto);
    }
}
