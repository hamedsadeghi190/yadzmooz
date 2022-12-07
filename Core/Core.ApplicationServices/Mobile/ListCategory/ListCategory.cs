using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ListCategory : IListCategory
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ListCategory
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ListCategoryResultDto Execute(ListCategoryDto dto)
        {

            return new ListCategoryResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = unit.Categories.GetByLanguage(dto.LanguageId)

            };

        }

        public ListCategoryMobileResultDto MobileExecute(ListCategoryDto dto)
        {


            var user = unit.Users.GetUserById(dto.UserId);

            var obj = new ListCategoryResultObject();
            var passed = user.Challenges?.FindAll(p => p.SubCategory.Id == user.LastSubCategory?.SubCategory.Id);
            obj.LastSubCategory = new LastSubCategoryObject();
            obj.LastSubCategory.CategoryTitle = user.LastSubCategory?.Category.Title;
            obj.LastSubCategory.Title = user.LastSubCategory?.SubCategory.Title;
            obj.LastSubCategory.ChallengeCount = (user.LastSubCategory?.SubCategory.Id != null) ? (unit.SubCategories.GetChallengeCount(user.LastSubCategory?.SubCategory.Id)) : 0;
            obj.LastSubCategory.ChallengePassed = passed == null ? 0 : passed.Count;
            obj.LastSubCategory.Icon = user.LastSubCategory?.SubCategory.Icon;
            obj.LastSubCategory.Id = user.LastSubCategory?.SubCategory.Id;
            obj.Categories = unit.Categories.GetByLanguage(dto.LanguageId);
            return new ListCategoryMobileResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = obj
            };

        }
    }
}
