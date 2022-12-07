using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo
{
    public class UnitOfWork : IUnitOfWork
    {


        public UnitOfWork(
            IChallengeRepository Challenges,
            IUserRepository Users,
            ILessonRepository Lessons,
            IExpressionRepository Expressions,
            IUpdateRepository   Updates,
            ICheckPointRepository CheckPoints,
            ILanguageRepository Languages,
            ICourseRepository Courses,
            IWordRepository Words,
            IDeviceRepository DeviceCodes,
            ITransactionsRepository Transactions,
            IFileRequestRepository FileRequest,
            ISubscriptionRepository Subscriptions,
            IActivationCodeRepository ActivationCodes,
            IDeviceRepository Devices,
            ICategoryRepository Categories,
            ISubCategoryRepository SubCategories
            )
        {
            this.Challenges = Challenges;
            this.Users = Users;
            this.Lessons = Lessons;
            this.Expressions = Expressions;
            this.Updates = Updates;
            this.CheckPoints = CheckPoints;
            this.Languages = Languages;
            this.Courses = Courses;
            this.Words = Words;
            this.DeviceCodes = DeviceCodes;
            this.Transactions = Transactions;
            this.FileRequest = FileRequest;
            this.Subscriptions = Subscriptions;
            this.ActivationCodes = ActivationCodes;
            this.Devices = Devices;
            this.Categories = Categories;
            this.SubCategories = SubCategories;
        }

        public IChallengeRepository Challenges { get; set; }
        public IUserRepository Users { get; set; }
        public ILessonRepository Lessons { get; set; }
        public IExpressionRepository Expressions { get; set; }
        public IUpdateRepository Updates { get; set; }
        public ICheckPointRepository CheckPoints { get; set; }
        public ILanguageRepository Languages { get; set; }
        public ICourseRepository Courses { get; set; }
        public IWordRepository Words { get; set; }
        public IDeviceRepository DeviceCodes { get; set; }
        public ITransactionsRepository Transactions { get; set; }
        public IFileRequestRepository FileRequest { get; set; }
        public ISubscriptionRepository Subscriptions { get; set; }
        public IActivationCodeRepository ActivationCodes { get; set; }
        public IDeviceRepository Devices { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ISubCategoryRepository SubCategories { get; set; }
    }
}
