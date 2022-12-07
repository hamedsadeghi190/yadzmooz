using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IChallengeRepository
    {
        void Insert(Challenge chal);
        List<Challenge> GetAll();
        Challenge GetById(Guid id);
        void Replace(Challenge chal);
        void Delete(Guid id);
        List<Challenge> GetBySubCategory(Guid subCategoryId);
        Challenge getByLuuid(string v);
        Challenge getByWord(string v);
        void InsertMany(List<Challenge> challenges);
    }
}
