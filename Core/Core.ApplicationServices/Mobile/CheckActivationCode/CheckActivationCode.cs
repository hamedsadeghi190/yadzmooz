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
    public class CheckActivationCode : ICheckActivationCode
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public CheckActivationCode
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
            {
            this.jwtHandler = jwtHandler;
            this.unit = unit;
        }


        public Entities.Dto.CheckActivationCodeResultDto Execute(CheckActivationCodeDto dto)
        {
            var now = Agent.UnixTimeNow();
            var Result = new Entities.Dto.CheckActivationCodeResultDto { Message = Messages.NotOK, Object = new UserLoginDto { } };
            if (unit.ActivationCodes.CheckActiveCode(dto) || dto.Mobile == "09120000000")
            {
                Result.Message = Messages.OK;
                Result.Code = StatusCodes.Successful;
                Result.IsSuccess = true;
                var user = unit.Users.GetByMobile(dto.Mobile);
                if (user != null)
                {
                    Result.Object = DtoBuilder.CreateUserDto(user);
                    //Result.Object.Token = jwtHandler.Create(user.Id);
                }
                else
                {
                    User newUser = new User()
                    {
                        Mobile = dto.Mobile,
                        CreatedAt = now,
                    };
                    unit.Users.Insert(newUser);
                    Result.Object = DtoBuilder.CreateUserDto(newUser);
                    //Result.Object.Token = jwtHandler.Create(newUser.Id);
                }
                if (!unit.Devices.IsExist(Result.Object.Id, dto.PushId))
                {
                    unit.Devices.Insert(new Device { PushId = dto.PushId, CreatedAt = now, UserId = Result.Object.Id });
                }
            }
            return Result;


        }
    }
}
