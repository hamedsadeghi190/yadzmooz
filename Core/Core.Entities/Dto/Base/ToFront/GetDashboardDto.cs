using Core.Entities.Mongo.Dto;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetDashboardDto
    {

    }
    public class GetDashboardResultDto : BaseApiResult
    {
        public Dashboard Object { get; set; }
    }

    public class Dashboard
    {

    }
    
}
