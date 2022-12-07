using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IMongoDatabase database;

        public CategoryRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Category> categories => database.GetCollection<Category>("Categories");

        public void Replace(Category cat)
        {
            categories.ReplaceOne(p => p.Id == cat.Id, cat);
        }

        public List<Category> GetAll()
        {
            return categories.Find(p => true).ToList();
        }

        public Category GetById(Guid id)
        {
            return categories.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Category cat)
        {
            categories.InsertOne(cat);
        }

        public void Delete(Guid id)
        {
            categories.DeleteOne(p => p.Id == id);
        }

        public List<Category> GetByLanguage(Guid languageId)
        {
            return categories.Find(p => p.LanguageId == languageId).ToList();
        }
        public void AddSubCategoryToCategory(AddSubCategoryDto dto, Guid id)
        {
            var category = GetById(dto.CategoryId);

            if (category.SubCategories == null)
            {
                category.SubCategories = new List<ShortSubCategory>();
            }

            category.SubCategories?.Add(new ShortSubCategory
            {
                Icon = dto.Icon,
                Id = id,
                Title = dto.Title,
            });

            Replace(category);
        }

        public void DeleteSubCategory(Guid id, Guid categoryId)
        {
            var category = GetById(categoryId);
            category.SubCategories.Remove(category.SubCategories.Find(p => p.Id == id));
            Replace(category);
        }

        public void EditSubCategoryInCategory(SubCategory cat)
        {
            var category = categories.Find(p => p.Id == cat.CategoryId).FirstOrDefault();

            var obj = category.SubCategories.Find(x => x.Id == cat.Id);
            if (obj != null)
            {
                obj.Icon = cat.Icon;
                obj.Title = cat.Title;
            }
            Replace(category);
        }

        public Guid GetLanguageByCategory(Guid? categoryId)
        {
            return categories.Find(p => p.Id == categoryId).FirstOrDefault().LanguageId;
        }
    }
}
