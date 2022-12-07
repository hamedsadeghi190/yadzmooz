using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.General;

namespace Infrastructure.Mongo.Services
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoDatabase database;

        public UserRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<User> users=> database.GetCollection<User>("Users");

        public User GetById(Guid userId)
        {
            return users.Find(p => p.Id == userId).FirstOrDefault();
        }
        public List<User> GetAll()
        {
            return users.Find(p=>true).ToList();

        }

        public User GetByMobile(string mobile)
        {
            return users.Find(p=>p.Mobile==mobile).FirstOrDefault();
        }

        public User GetUserById(Guid id)
        {
            return users.Find(p=>p.Id ==id).FirstOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            return users.Find(p => p.UserName == userName).FirstOrDefault();

        }

        public void Insert(User newUser)
        {
            users.InsertOne(newUser);
        }

        public void Update(User user)
        {
            users.ReplaceOne(p => p.Id == user.Id , user);
        }
        public bool UserNameExist(string userName)
        {
            var user = users.Find(p=> p.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
