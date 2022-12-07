using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class LessonRepository : ILessonRepository
    {

        private readonly IMongoDatabase database;

        public LessonRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Lesson> lessons => database.GetCollection<Lesson>("Lessons");

    }
}
