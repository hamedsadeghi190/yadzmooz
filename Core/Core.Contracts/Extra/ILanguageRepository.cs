using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface ILanguageRepository
    {
        void Insert(Language lang);
        List<Language> GetAll();
        Language GetLanguageById(Guid id);
        void Replace(Language lang);
        void Delete(Guid id);
        void AddCategoryToLanguage(AddCategoryDto dto, Guid id);
        void DeleteCategory(Guid id, Guid languageId);
        void EditCategoryInLanguages(Category cat);
        Language GetLanguageByCategoryId(Guid categoryId);
    }
}
