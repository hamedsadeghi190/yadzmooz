using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class ChallengeRepository : IChallengeRepository
    {

        private readonly IMongoDatabase database;

        public ChallengeRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Challenge> challenges=> database.GetCollection<Challenge>("Challenges");

        public void Replace(Challenge cat)
        {
            challenges.ReplaceOne(p => p.Id == cat.Id, cat);
        }

        public List<Challenge> GetAll()
        {
            return challenges.Find(p => true).ToList();
        }

        public Challenge GetById(Guid id)
        {
            return challenges.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Challenge cat)
        {
            challenges.InsertOne(cat);
        }

        public void Delete(Guid id)
        {
            challenges.DeleteOne(p => p.Id == id);
        }


        public List<Challenge> GetBySubCategory(Guid subCategoryId)
        {
            return challenges.Find(p => p.SubCategoryId == subCategoryId).ToList();
        }

        public Challenge getByLuuid(string v)
        {
            return challenges.Find(p => p.Id == new Guid(v)).FirstOrDefault();
        }

        public Challenge getByWord(string v)
        {
            return challenges.Find(p => p.Word == v).FirstOrDefault();
        }

        public void InsertMany(List<Challenge> chall)
        {
            challenges.InsertMany(chall);
        }
    }
}
