using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mongo.Contracts
{
    public interface IUnitOfWork
    {
            
        IChallengeRepository Challenges{ get; set; }
        IWordRepository Words{ get; set; }
        IUserRepository Users { get; set; }
        ILessonRepository Lessons{ get; set; }
        IExpressionRepository Expressions{ get; set; }
        IUpdateRepository Updates{ get; set; }
        ISubscriptionRepository Subscriptions { get; set; }
        IFileRequestRepository FileRequest { get; set; }
        ICheckPointRepository CheckPoints{ get; set; }
        ILanguageRepository Languages{ get; set; }
        ITransactionsRepository Transactions{ get; set; }
        ICategoryRepository Categories { get; set; }    
        ISubCategoryRepository SubCategories { get; set; }    
        ICourseRepository Courses{ get; set; }
        IDeviceRepository DeviceCodes{ get; set; }    
        IActivationCodeRepository ActivationCodes{ get; set; }
        IDeviceRepository Devices{ get; set; }



    }
}
