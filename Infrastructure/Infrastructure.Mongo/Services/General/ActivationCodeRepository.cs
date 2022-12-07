using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class ActivationCodeRepository : IActivationCodeRepository
    {

        private readonly IMongoDatabase database;

        public ActivationCodeRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<ActivationCode> activationCodes => database.GetCollection<ActivationCode>("ActivationCodes");


        public bool CheckActiveCode(CheckActivationCodeDto dto)
        {
            var date = DateTime.Now.AddMinutes(-15).ToUnix();

            var result = activationCodes.Find(p => p.Mobile == dto.Mobile && p.CreatedAt > date).
                ToList().
                OrderByDescending(p => p.CreatedAt).
                ToList().FirstOrDefault();
            return result != null && result.Code == dto.Code;
        }

        public bool CheckExeed(string mobile)
        {
            var date = DateTime.Now.AddMinutes(-15).ToUnix();
            return activationCodes.Find(p => p.Mobile == mobile && p.CreatedAt > date).ToList().Count >= 2;
        }

        public void Insert(ActivationCode activationCode)
        {
            activationCodes.InsertOne(activationCode);
        }


    }
}
