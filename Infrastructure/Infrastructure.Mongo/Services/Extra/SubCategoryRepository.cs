using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class SubCategoryRepository : ISubCategoryRepository
    {

        private readonly IMongoDatabase database;

        public SubCategoryRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<SubCategory> subCategories=> database.GetCollection<SubCategory>("SubCategories");

        public void Replace(SubCategory cat)
        {
            subCategories.ReplaceOne(p => p.Id == cat.Id, cat);
        }

        public List<SubCategory> GetAll()
        {
            return subCategories.Find(p => true).ToList(); 
        }

        public SubCategory GetById(Guid id)
        {
            return subCategories.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(SubCategory cat)
        {
            subCategories.InsertOne(cat);
        }

        public void Delete(Guid id)
        {
            subCategories.DeleteOne(p => p.Id == id);
        }



        public List<SubCategory> GetByCategory(Guid categoryId)
        {
            var subs = subCategories.Find(p => p.CategoryId == categoryId).ToList();
            if (subs?.Count == 0)
            {
                return null;
            }
            else
            {
                return subs;
            }
        }


        public void AddChallengeToSubCategory(Guid id, Guid SubId)
        {
            var subCategory = GetById(SubId);

            if (subCategory.Challenges == null)
            {
                subCategory.Challenges = new List<ShortChallenge>();
            }

            subCategory.Challenges?.Add(new ShortChallenge
            {
                Id = id,
            });

            Replace(subCategory);
        }

        public void DeleteChallenge(Guid id, Guid subCategoryId)
        {
            var subCategory = GetById(subCategoryId);
            subCategory.Challenges.Remove(subCategory.Challenges.Find(p => p.Id == id));
            Replace(subCategory);
        }

        public int GetChallengeCount(Guid? id)
        {
            return subCategories.Find(p => p.Id == id).FirstOrDefault().Challenges.Count;
        }

        public Guid GetCategoryBySubCategory(Guid subCategoryId)
        {
            return subCategories.Find(p => p.Id == subCategoryId).FirstOrDefault().CategoryId;
        }

        public void AddChallengesToSubCategory(List<Challenge> challenges , Guid subCategoryId)
        {
            var subCategory = GetById(subCategoryId);

            if (subCategory.Challenges == null)
            {
                subCategory.Challenges = new List<ShortChallenge>();
            }


            foreach (var item in challenges)
            {
                subCategory.Challenges?.Add(new ShortChallenge
                {
                    Id = item.Id
                });
            }

            Replace(subCategory);
        }

        public List<ArrangeSubCategoryIntryObject> GetByCategoryByArrange(Guid categoryId)
        {
            var subs = subCategories.Find(p => p.CategoryId == categoryId).SortBy(p=>p.Piority).ToList();
            if (subs?.Count == 0)
            {
                return null;
            }
            else
            {
                List<ArrangeSubCategoryIntryObject> su = new List<ArrangeSubCategoryIntryObject>();

                foreach (var item in subs)
                {
                    su.Add(new ArrangeSubCategoryIntryObject
                    {
                        Id = item.Id,
                        Piority = item.Piority,
                        Name = item.Title
                    });
                }

                return su;
            }
        }
    }
}
