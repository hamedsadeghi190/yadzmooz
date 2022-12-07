using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.General;

namespace Infrastructure.Mongo.Services
{
    public class UpdateRepository : IUpdateRepository
    {

        private readonly IMongoDatabase database;

        public UpdateRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Update> updates => database.GetCollection<Update>("Updates");

        public void AddUpdate(AddCheckUpdateDto dto)
        {
            var update = updates.Find(p => true).FirstOrDefault();


            if (update == null)
            {
                updates.InsertOne(new Update
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = Agent.Now,
                    Description = dto.Description,
                    Link = dto.Link,
                    Restricted = dto.Restricted,
                    Version = dto.Version,
                });
            }
            else
            {
                update.Description = dto.Description;
                update.Link = dto.Link;
                update.Restricted = dto.Restricted;
                update.Version = dto.Version;

                updates.ReplaceOne(p => p.Id == update.Id, update);
            }

          
   
        }



        public CheckUpdateResultDto CheckUpdate()
        {
            return new CheckUpdateResultDto
            {
                Message = Messages.Success,
                Code = 0,
                IsSuccess = true,
                Object = updates.Find(p => true).First()

            };
        }
    }
}
