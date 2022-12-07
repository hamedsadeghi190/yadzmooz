using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        private readonly IMongoDatabase database;

        public SubscriptionRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Subscription> subscriptions => database.GetCollection<Subscription>("Subscriptions");

        public void Replace(Subscription lang)
        {
            subscriptions.ReplaceOne(p => p.Id == lang.Id, lang);
        }

        public List<Subscription> GetAll()
        {
            return subscriptions.Find(p => true).ToList();
        }

        public Subscription GetById(Guid id)
        {
            return subscriptions.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Subscription lang)
        {
            subscriptions.InsertOne(lang);
        }

        public void Delete(Guid id)
        {
            subscriptions.DeleteOne(p => p.Id == id);
        }


    }
}
