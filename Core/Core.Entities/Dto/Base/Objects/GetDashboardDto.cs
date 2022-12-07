using System;
using System.Collections.Generic;
using System.Configuration;

namespace Core.Entities.Mongo.Dto
{
    public class GetDashboardDto
    {
        public int ProvienceId { get; set; }
    }
    public class GetDashboardResultDto : BaseApiResult
    {
        public Dashboard Object { get; set; }
    }

    public class Dashboard
    {
        public TodayStatistic TodayClientCount { get; set; }
        public TodayStatistic TodayKargozariCount { get; set; }
        public TodayStatistic TodayEmployeeCount { get; set; }
        public TransactionModel AllTransactionCount { get; set; }
        public TransactionModel LastMonthTransactionCount { get; set; }
        public TransactionModel LastWeekTransactionCount { get; set; }
        public TransactionModel TodayTransactionCount { get; set; }
        public ProvienceStatistic  ProvienceStatistic{ get; set; }
    }

    public class TodayStatistic
    {
        public int Count { get; set; }
        public double Percent{ get; set; }
    }

    public class TransactionModel
    {
        public int All { get; set; }
        public int Successful { get; set; }
        public int UnSuccessful { get; set; }
    }
    public class ProvienceStatistic
    {
        public int RequestCount{ get; set; }
        public int KargozariCount { get; set; }
        public int EmployeeCount { get; set; }
    }
    
}
