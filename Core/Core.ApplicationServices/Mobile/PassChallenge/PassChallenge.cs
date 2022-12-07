using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class PassChallenge : IPassChallenge
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IConfiguration configuration;

        public PassChallenge
            (
            IUnitOfWork unit
            , INotification notification,
            IConfiguration configuration
            )
        {
            this.unit = unit;
            this.notification = notification;
            this.configuration = configuration;
        }


        public PassChallengeResultDto Execute(PassChallengeDto dto)
        {

            var result = new PassChallengeResultDto()
            {
                Code = 0,
                IsSuccess = false,
                Message = Messages.UserNotExist,
                
            };

            var user = unit.Users.GetUserById(dto.UserId);

            if (user != null)
            {


                var challenge = unit.Challenges.GetById(dto.ChallengeId);

                if (challenge == null)
                {
                    result.IsSuccess = false;
                    result.Message = Messages.ChallengeDoesNotExist;
                    result.Code = StatusCodes.Successful;
                }
                else
                {



                 


                    try
                    {


                        var subCategory = unit.SubCategories.GetById(dto.SubCategoryId);
                        var category = unit.Categories.GetById(subCategory.CategoryId);
                        var language = unit.Languages.GetLanguageById(category.LanguageId);


                        var userChallenge = new UserChallenge
                        {

                            Category = new ShortCategory { Icon = category.Icon, Id = category.Id, Title = category.Title },
                            SubCategory = new ShortSubCategory { Icon = subCategory.Icon, Id = subCategory.Id, Title = subCategory.Title },
                            Language = new ShortLanguage { Id = language.Id, Title = language.Title, Icon = language.Icon },
                            Title = challenge.Title,
                            Meanings = challenge.Meanings,
                            Word = challenge.Word,

                        };

                        if (user.Challenges == null)
                        {
                            user.Challenges = new List<UserChallenge>();
                        }

                        user.Challenges.Add(userChallenge);
                        user.LastSubCategory = userChallenge;

                        unit.Users.Update(user);


                        result.IsSuccess = true;
                        result.Message = Messages.OK;
                        result.Code = StatusCodes.Successful;


                        return result; 

                    }
                    catch (Exception)
                    {

                        result.IsSuccess = false;
                        result.Message = "خطایی پیش آمده است";
                        result.Code = 101;
                    }


                    
                }

            }
            
            
            return result;

        }
    }
}
