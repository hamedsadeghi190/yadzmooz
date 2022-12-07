using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface ITransactionsRepository
    {
        void Insert(Transactions lang);
        List<Transactions> GetAll();
        Transactions GetById(Guid id);
        void Replace(Transactions lang);
        void Delete(Guid id);
        Transactions GetByOrderId(long orderId);
    }
}
