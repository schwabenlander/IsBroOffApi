using System;

namespace IsBroOffApi.Services
{
    public interface IScheduleService
    {
        bool IsBroOff(DateTime date);
    }
}