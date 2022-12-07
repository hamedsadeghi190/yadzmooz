using System;

namespace Core.Entities.Mongo.Dto
{
    public class BaseByGuidIdDto
    {
        public Guid Id{ get; set; }
    }
    public class BaseByIntIdDto
    {
        public int Id{ get; set; }
    }
    
    public class BaseByPageDto
    {
        public int PageNo { get; set; }
    }
    public class BaseByUserDto
    {
        public Guid? UserId { get; set; }
    }
    public class BaseByUserPageDto
    {
        public int PageNo { get; set; }
        public Guid? UserId { get; set; }
    }
    public class NameDto
    {
        public string Name { get; set; }
    }
    public class BaseByDoublePriceDto
    {
        public double Balance{ get; set; }
    }
}
