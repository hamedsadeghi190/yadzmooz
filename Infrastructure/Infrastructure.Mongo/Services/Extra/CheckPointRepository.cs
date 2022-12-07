using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class CheckPointRepository : ICheckPointRepository
    {

        private readonly IMongoDatabase database;

        public CheckPointRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<CheckPoint> checkPoints => database.GetCollection<CheckPoint>("CheckPoints");

    }
}
