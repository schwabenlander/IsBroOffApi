using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsBroOffApi.Models;
using IsBroOffApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IsBroOffApi.Controllers
{
    [Route("api/bro")]
    [ApiController]
    public class BroController : ControllerBase
    {
        private readonly IBroDetailsService _broDetailsService;
        private readonly ILogger _logger;

        public BroController(IBroDetailsService broDetailsService, 
                             ILogger<BroController> logger)
        {
            _broDetailsService = broDetailsService;
            _logger = logger;
        }

        [HttpGet("details")]
        [ProducesResponseType(200)]
        public ActionResult<BroDetailsDto> GetDetails()
        {
            _logger.LogInformation("Getting bro's details.");

            return Ok(_broDetailsService.GetBroDetails());
        }
    }
}
