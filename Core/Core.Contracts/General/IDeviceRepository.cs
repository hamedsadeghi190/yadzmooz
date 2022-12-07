using Core.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Mongo.Contracts
{
    public interface IDeviceRepository
    {
        bool IsExist(Guid id, string pushId);
        void Insert(Device device);
    }
}
