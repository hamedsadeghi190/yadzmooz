using Core.Entities.Dto;
using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IUserRepository
    {
        void Insert(User newUser);
        User GetByMobile(string mobile);
        User GetUserById(Guid id);
        bool UserNameExist(string userName);
        void Update(User user);
        User GetById(Guid userId);
        List<User> GetAll();

    }
}
