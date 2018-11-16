using System;

namespace IsBroOffApi.Services
{
    public interface IScheduleService
    {
        DateTime FirstDayOffDate { get; }
        bool IsBroOff(DateTime date);
    }
}