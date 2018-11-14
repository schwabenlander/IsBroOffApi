﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IsBroOffApi.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IConfiguration _configuration;
        private DateTime FirstDayOffDate { get; }
        private int DaysInCycle { get; }
        private int DaysOnDuty { get; }

        public ScheduleService(IConfiguration configuration)
        {
            _configuration = configuration;
            FirstDayOffDate = DateTime.Parse(_configuration["ScheduleSettings:FirstDayOffDate"]);
            DaysInCycle = Int32.Parse(_configuration["ScheduleSettings:DaysInCycle"]);
            DaysOnDuty = Int32.Parse(_configuration["ScheduleSettings:DaysOnDuty"]);
        }

        public bool IsBroOff(DateTime date)
        {
            if (date < FirstDayOffDate)
                throw new ArgumentOutOfRangeException();

            var daysSinceKnownFirstDayOff = (date.Date - FirstDayOffDate.Date).Days;
            var carrier = daysSinceKnownFirstDayOff % DaysInCycle;

            if (carrier >= 0 && carrier < DaysOnDuty)
                return true;

            return false;
        }
    }
}
