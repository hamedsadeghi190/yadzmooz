using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface ISubCategoryRepository
    {
        void Insert(SubCategory cat);
        List<SubCategory> GetAll();
        SubCategory GetById(Guid id);
        void Replace(SubCategory cat);
        void Delete(Guid id);
        List<SubCategory> GetByCategory(Guid categoryId);

        List<ArrangeSubCategoryIntryObject> GetByCategoryByArrange(Guid categoryId);

        void AddChallengeToSubCategory(Guid id, Guid SubId);
        void DeleteChallenge(Guid id, Guid subCategoryId);
        int GetChallengeCount(Guid? id);
        Guid GetCategoryBySubCategory(Guid subCategoryId);
        void AddChallengesToSubCategory(List<Challenge> challenges, Guid subCategoryId);
    }
}
