using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class TransactionsRepository : ITransactionsRepository
    {

        private readonly IMongoDatabase database;

        public TransactionsRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Transactions> transactions => database.GetCollection<Transactions>("Transactions");

        public void Replace(Transactions lang)
        {
            transactions.ReplaceOne(p => p.Id == lang.Id, lang);
        }

        public List<Transactions> GetAll()
        {
            return transactions.Find(p => true).ToList();
        }

        public Transactions GetById(Guid id)
        {
            return transactions.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Transactions trans)
        {
            transactions.InsertOne(trans);
        }

        public void Delete(Guid id)
        {
            transactions.DeleteOne(p => p.Id == id);
        }

        public Transactions GetByOrderId(long orderId)
        {
            return transactions.Find(p => p.OrderId == orderId).FirstOrDefault();
        }
    }
}
