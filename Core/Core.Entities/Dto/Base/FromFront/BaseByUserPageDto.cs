using System;

namespace Core.Entities.Dto
{
    public class BaseByUserPageDto
    {
        public int PageNo{ get; set; }
        public Guid? UserId { get; set; }
    }
}
