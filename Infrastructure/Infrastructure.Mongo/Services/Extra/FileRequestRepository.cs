using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class FileRequestRepository : IFileRequestRepository
    {

        private readonly IMongoDatabase database;

        public FileRequestRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<FileRequest> fileRequest => database.GetCollection<FileRequest>("FileRequests");

        public void Replace(FileRequest cat)
        {
            fileRequest.ReplaceOne(p => p.Id == cat.Id, cat);
        }

        public List<FileRequest> GetAll()
        {
            return fileRequest.Find(p => true).ToList(); 
        }

        public FileRequest GetById(Guid id)
        {
            return fileRequest.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(FileRequest cat)
        {
            fileRequest.InsertOne(cat);
        }

        public void Delete(Guid id)
        {
            fileRequest.DeleteOne(p => p.Id == id);
        }





       
    }
}
