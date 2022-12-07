using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class UserController : SimpleController
    {
        private readonly IGetUserById getUserById;
        private readonly IEditProfile editProfile;
        private readonly IGetUsers getUsers;
        private readonly IGetUserSubscriptions getUsersSubscriptions;
        private readonly ICheckUserLicense checkUserLicense;
        private readonly IAddTransactionToUser addTransactionToUser;

        public UserController(
            IGetUserById getUserById,
            IEditProfile editProfile,
            IGetUsers getUsers,
            IGetUserSubscriptions getUsersSubscriptions,
            ICheckUserLicense checkUserLicense,
            IAddTransactionToUser addTransactionToUser
            )
        {
            this.getUserById = getUserById;
            this.editProfile = editProfile;
            this.getUsers = getUsers;
            this.getUsersSubscriptions = getUsersSubscriptions;
            this.checkUserLicense = checkUserLicense;
            this.addTransactionToUser = addTransactionToUser;
        }

        [HttpGet]
        public ActionResult<GetUserByIdResultDto> GetById([FromQuery] GetUserByIdDto dto )
        {
            return getUserById.Execute(dto);
        }

        [HttpGet]
        public ActionResult<GetUsersResultDto> List([FromQuery] GetUsersDto dto)
        {
            return getUsers.Execute(dto);
        }
        [HttpGet]
        public ActionResult<GetUserSubscriptionsResultDto> GetUserSubscriptions([FromQuery] GetUserSubscriptionsDto dto)
        {
            return getUsersSubscriptions.Execute(dto);
        }

        [HttpPost]
        public ActionResult<CheckUserLicenseResultDto> CheckUserLicense([FromBody] CheckUserLicenseDto dto)
        {
            return checkUserLicense.Execute(dto);
        }

        [HttpPut]
        public ActionResult<EditProfileResultDto> EditProfile([FromBody] EditProfileDto dto)
        {
            return editProfile.Execute(dto);
        }
        [HttpPost]
        public ActionResult<AddTransactionToUserResultDto> AddTransactionToUser([FromBody] AddTransactionToUserDto dto)
        {
            return addTransactionToUser.Execute(dto);
        }

    }
}
