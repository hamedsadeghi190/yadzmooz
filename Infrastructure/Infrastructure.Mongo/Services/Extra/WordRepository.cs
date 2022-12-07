using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class WordRepository : IWordRepository
    {

        private readonly IMongoDatabase database;

        public WordRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Words> words => database.GetCollection<Words>("Words");

        public void Replace(Words cat)
        {
            words.ReplaceOne(p => p.Id == cat.Id, cat);
        }

        public List<Words> GetAll()
        {
            return words.Find(p => true).ToList();
        }

        public Words GetById(Guid id)
        {
            return words.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Words cat)
        {
            words.InsertOne(cat);
        }

        public void Delete(Guid id)
        {
            words.DeleteOne(p => p.Id == id);
        }


        public List<Words> GetBySubCategory(Guid subCategoryId)
        {
            return words.Find(p => p.SubCategoryId == subCategoryId).ToList();
        }

        public Words getByLuuid(string v)
        {
            return words.Find(p => p.Id == new Guid(v)).FirstOrDefault();
        }

        public Words getByWord(string v)
        {
            return words.Find(p => p.Word == v).FirstOrDefault();
        }

        public ListWordObejct GetByLanguage(ListWordDto dto)
        {

            if (dto.CategoryId == null)
            {
                var a = words.Find(p =>
                  (dto.Status == 0 || dto.Status == p.Status) &&
                  p.LanguageId == dto.LanguageId );

                var b = a.CountDocuments();




                return new ListWordObejct
                {
                    Object = a.Skip((dto.PageCount == 0 ? 10 : dto.PageCount) * (dto.PageNo - 1)).Limit(dto.PageCount == 0 ? 10 : dto.PageCount).ToList(),
                    Total = b
                };

            }
            else if(dto.SubCategoryId == null)
            {
                var a = words.Find(p =>
                  (dto.Status == 0 || dto.Status == p.Status) &&
                  p.LanguageId == dto.LanguageId && p.CategoryId == dto.CategoryId);


                var b = a.CountDocuments();




                return new ListWordObejct
                {
                    Object = a.Skip((dto.PageCount == 0 ? 10 : dto.PageCount) * (dto.PageNo - 1)).Limit(dto.PageCount == 0 ? 10 : dto.PageCount).ToList(),
                    Total = b
                };
            }
            else
            {
                var a = words.Find(p =>
                 (dto.Status == 0 || dto.Status == p.Status) &&
                 p.LanguageId == dto.LanguageId && p.CategoryId == dto.CategoryId && dto.SubCategoryId == dto.SubCategoryId);


                var b = a.CountDocuments();




                return new ListWordObejct
                {
                    Object = a.Skip((dto.PageCount == 0 ? 10 : dto.PageCount) * (dto.PageNo - 1)).Limit(dto.PageCount == 0 ? 10 : dto.PageCount).ToList(),
                    Total = b
                };
            }






 

        }

        public List<Words> FindBySubCateoryId(Guid subCategoryId)
        {
            return words.Find(p => p.SubCategoryId == subCategoryId).ToList();
        }

        public bool CheckExist(string word)
        {
            var wor = words.Find(p => p.Word == word).FirstOrDefault();
            return wor != null ? true : false;
        }

        public List<Words> GetForChallenge(ListWordDto dto)
        {
            return words.Find(p => (dto.Status == 0 || dto.Status == p.Status)).Limit(5).ToList();
        }
    }
}
