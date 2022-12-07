using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface ISubscriptionRepository
    {
        void Insert(Subscription lang);
        List<Subscription> GetAll();
        Subscription GetById(Guid id);
        void Replace(Subscription lang);
        void Delete(Guid id);

    }
}
