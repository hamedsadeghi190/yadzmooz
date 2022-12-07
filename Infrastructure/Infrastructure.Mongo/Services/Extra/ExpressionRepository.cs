using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class ExpressionRepository : IExpressionRepository
    {

        private readonly IMongoDatabase database;

        public ExpressionRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Expression> expressions => database.GetCollection<Expression>("Expressions");

    }
}
