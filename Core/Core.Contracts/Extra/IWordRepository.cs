using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IWordRepository
    {
        void Insert(Words w);
        List<Words> GetAll();
        Words GetById(Guid id);
        void Replace(Words w);
        void Delete(Guid id);
        List<Words> GetBySubCategory(Guid subCategoryId);
        Words getByLuuid(string v);
        Words getByWord(string v);
        ListWordObejct GetByLanguage(ListWordDto dto);
        List<Words> FindBySubCateoryId(Guid subCategoryId);
        bool CheckExist(string word);
        List<Words> GetForChallenge(ListWordDto dto);
    }
}
