using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface ICategoryRepository
    {
        void Insert(Category cat);
        List<Category> GetAll();
        Category GetById(Guid id);
        void Replace(Category cat);
        void Delete(Guid id);
        List<Category> GetByLanguage(Guid languageId);
        void AddSubCategoryToCategory(AddSubCategoryDto dto, Guid id);
        void DeleteSubCategory(Guid id, Guid categoryId);
        void EditSubCategoryInCategory(SubCategory cat);
        Guid GetLanguageByCategory(Guid? categoryId);
    }
}
