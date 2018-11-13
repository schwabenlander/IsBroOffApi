using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsBroOffApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsBroOffApi.Controllers
{
    [Route("api/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        // GET api/calendar/2018/11/13
        [HttpGet("{yyyy}/{mm}/{dd}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<WorkStatusDto> GetWorkStatusForDate(int yyyy, int mm, int dd)
        {
            DateTime.TryParse($"{yyyy}-{mm}-{dd}", out var date);

            if (date == DateTime.MinValue)
                return BadRequest();

            return new WorkStatusDto
            {
                Date = date,
                DateAsString = date.ToLongDateString(),
                IsBroOff = true,
                StatusText = "Bro is off today"
            };
        }
    }
}
