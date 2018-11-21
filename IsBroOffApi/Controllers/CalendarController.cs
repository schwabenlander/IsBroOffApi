using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsBroOffApi.Models;
using IsBroOffApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IsBroOffApi.Controllers
{
    [Route("api/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger _logger;

        public CalendarController(IScheduleService scheduleService, 
                                  ILogger<CalendarController> logger)
        {
            _scheduleService = scheduleService;
            _logger = logger;
        }

        // GET api/calendar/2018/11/13
        [HttpGet("{yyyy}/{mm}/{dd}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<WorkStatusDto> GetWorkStatusForDate(int yyyy, int mm, int dd)
        {
            DateTime.TryParse($"{yyyy}-{mm}-{dd}", out var date);

            try
            {
                var isBroOff = _scheduleService.IsBroOff(date);

                _logger.LogInformation($"Getting work status for: {date.ToShortDateString()}");

                return new WorkStatusDto
                {
                    Date = date,
                    IsBroOff = isBroOff
                };
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, 
                    "Exception occurred during attempt to get work status.", 
                    date);
                ModelState.AddModelError("Exception", exception.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/calendar/today
        [HttpGet("today")]
        [ProducesResponseType(200)]
        public ActionResult<WorkStatusDto> GetWorkStatusForToday()
        {
            var today = DateTime.Today;
            var isBroOff = _scheduleService.IsBroOff(today);

            _logger.LogInformation($"Getting work status today ({today.ToShortDateString()})");

            return new WorkStatusDto
            {
                Date = today,
                IsBroOff = isBroOff
            };
        }
    }
}
