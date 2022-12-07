using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class CourseRepository : ICourseRepository
    {

        private readonly IMongoDatabase database;

        public CourseRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Course> course => database.GetCollection<Course>("Courses");

    }
}
