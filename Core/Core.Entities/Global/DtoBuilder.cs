using Core.Entities.Dto;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Core.Entities.Functions
{
    public class DtoBuilder
    {
        public static LanguageDto CreateLanguageDto(Language language)
        {
            return new LanguageDto
            {
                Icon = language.Icon,
                Id = language.Id,
                Title = language.Title,
                LanguageType = language.LanguageType,
            };
        }

        public static ChallengeObject CreateChallengeObject(Challenge p, Guid id, Guid languageId)
        {

            return new ChallengeObject
            {
                Id = p.Id,
                Title = p.Title,
                LanguageId = languageId,
                CategoryId = id,    
                Meanings = p.Meanings,    
                Word = p.Word,    
                CorrectAnswer = p.CorrectAnswer,    
                Options = p.Options,    
                SubCategoryId= p.SubCategoryId,    
                Type= p.Type,    
            };
        }

        public static SubscriptionDto CreateSubscriptionDto(Subscription p)
        {
            return new SubscriptionDto
            {
                Id = p.Id,
                Title = p.Title,
                DiscountPercent = p.DiscountPercent,
                Price = p.Price,
                NumberOfDevice  = p.NumberOfDevice,
                ExpireMonths = p.ExpireMonths,
                Icon =  p.Icon,
            };
        }


        //public static UserDto CreateUserDto(User p)
        //{
        //    UserDto user = new UserDto
        //    {
        //        Birthday = p.Birthday,
        //        CreatedAt = p.CreatedAt,
        //        Email = p.Email,
        //        FamilyName = p.FamilyName,
        //        Gender = p.Gender,
        //        Id = p.Id,                
        //        Mobile = p.Mobile,
        //        PrinterIp = p.PrinterIp,
        //        Name = p.Name,
        //        UserName = p.UserName,
        //        ProfileImage = p.ProfileImage != null ? CreateFileDto(p.ProfileImage) : null,
        //        Status = p.Status,
        //        Description = p.Description,
        //        Store = p.Store,
        //        RoleId = p.RoleId
        //    };
        //    return user;
        //}
        public static UserLoginDto CreateUserDto(User p)
        {
            UserLoginDto result = new UserLoginDto {
                CreatedAt = p.CreatedAt,
                Email = p.Email,
                Image = p.Image,
                Age = p.Age,
                Id = p.Id,
                Mobile = p.Mobile,
                UserName = p.UserName
                //Token = null,
            };
            return result;

        }

        public static ChallengeOptions CreateChallengeOptionsByWord(Words word)
        {
            return new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word

            };
        }
    }
}
