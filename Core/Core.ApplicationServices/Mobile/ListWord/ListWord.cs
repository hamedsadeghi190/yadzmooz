using Core.Entities.Dto;
using Core.Mongo.Contracts;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ListWord : IListWord
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public ListWord
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public ListWordResultDto Execute(ListWordDto dto)
        {
            var a = unit.Words.GetByLanguage(dto);

            return new ListWordResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = a.Object,
                BlockSize = dto.PageCount,
                TotalCount =a.Total
           
            };

        }

        public ListWordResultDto GetForChallenge(ListWordDto listWordDto)
        {
            return new ListWordResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success,
                Object = unit.Words.GetForChallenge(listWordDto),
                BlockSize = 1,
                TotalCount = 1

            };
        }
    }
}
