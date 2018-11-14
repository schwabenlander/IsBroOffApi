using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsBroOffApi.Models;
using IsBroOffApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsBroOffApi.Controllers
{
    [Route("api/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public CalendarController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET api/calendar/2018/11/13
        [HttpGet("{yyyy}/{mm}/{dd}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<WorkStatusDto> GetWorkStatusForDate(int yyyy, int mm, int dd)
        {
            DateTime.TryParse($"{yyyy}-{mm}-{dd}", out var date);

            if (date == DateTime.MinValue)
                return BadRequest();

            var isBroOff = _scheduleService.IsBroOff(date);

            return new WorkStatusDto
            {
                Date = date,
                DateAsString = date.ToLongDateString(),
                IsBroOff = isBroOff,
                StatusText = isBroOff ? "Bro is off" : "Bro has work"
            };
        }
    }
}
