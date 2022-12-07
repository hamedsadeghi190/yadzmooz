using Core.Entities.Mongo;
using Core.Mongo.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mongo.Services
{
    public class DeviceRepository : IDeviceRepository
    {

        private readonly IMongoDatabase database;

        public DeviceRepository(IMongoDatabase database)
        {
            this.database = database;
        }
        private IMongoCollection<Device> devices => database.GetCollection<Device>("Devices");

        public void Insert(Device device)
        {
            this.devices.InsertOne(device);
        }

        public bool IsExist(Guid id, string pushId)
        {

            var userDevices = this.devices.Find(p=>p.UserId == id).ToList();

            foreach (var item in userDevices)
            {
                if (item.PushId == pushId)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
