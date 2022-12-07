using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IFileRequestRepository
    {
        void Insert(FileRequest cat);
        List<FileRequest> GetAll();
        FileRequest GetById(Guid id);
        void Replace(FileRequest cat);
        void Delete(Guid id);
     
    }
}
