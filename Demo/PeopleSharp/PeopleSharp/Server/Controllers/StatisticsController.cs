﻿using PeopleSharp.Server.Statistics;
using PeopleSharp.Shared.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace PeopleSharp.Server.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        [HttpGet("[action]")]
        public StatsEmployees GetStatsEmployees()
        {
            StatsEmployeesCalculator calc = new();
            
            return calc.CalculateStats();
        }

        [HttpGet("[action]")]
        public StatsCompany GetStatsCompany()
        {
            StatsCompanyCalculator calc = new();

            return calc.CalculateStats();
        }
    }
}
