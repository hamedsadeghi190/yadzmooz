using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class LanguageRepository : ILanguageRepository
    {

        private readonly IMongoDatabase database;

        public LanguageRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Language> languages => database.GetCollection<Language>("Languages");

        public void Replace(Language lang)
        {
            languages.ReplaceOne(p => p.Id == lang.Id, lang);
        }

        public List<Language> GetAll()
        {
            return languages.Find(p => true).ToList();
        }

        public Language GetLanguageById(Guid id)
        {
            return languages.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Language lang)
        {
            languages.InsertOne(lang);
        }

        public void Delete(Guid id)
        {
            languages.DeleteOne(p => p.Id == id);
        }

        public void AddCategoryToLanguage(AddCategoryDto dto, Guid id)
        {
            var language = GetLanguageById(dto.LanguageId);

            if (language.Categories == null)
            {
                language.Categories = new List<ShortCategory>();
            }

            language.Categories?.Add(new ShortCategory
            {
                Icon = dto.Icon,
                Id = id,
                Title = dto.Title,
            });

            Replace(language);

        }

        public void DeleteCategory(Guid id, Guid languageId)
        {
            var language = GetLanguageById(languageId);
            language.Categories.Remove(language.Categories.Find(p => p.Id == id));
            Replace(language);
        }

        public void EditCategoryInLanguages(Category cat)
        {
            var lang = languages.Find(p => p.Id == cat.LanguageId).FirstOrDefault();

            var obj = lang.Categories.Find(x => x.Id == cat.Id);
            if (obj != null) { 
                obj.Icon = cat.Icon;
                obj.Title = cat.Title;
            }
            Replace(lang);

        }

        public Language GetLanguageByCategoryId(Guid categoryId)
        {
            return languages.Find(p => p.Categories.Exists(t => t.Id == categoryId)).FirstOrDefault();
        }
    }
}
