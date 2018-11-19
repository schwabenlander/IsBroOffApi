using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsBroOffApi.Models;
using IsBroOffApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsBroOffApi.Controllers
{
    [Route("api/bro")]
    [ApiController]
    public class BroController : ControllerBase
    {
        private readonly IBroDetailsService _broDetailsService;

        public BroController(IBroDetailsService broDetailsService)
        {
            _broDetailsService = broDetailsService;
        }

        [HttpGet("details")]
        [ProducesResponseType(200)]
        public ActionResult<BroDetailsDto> GetDetails()
        {
            return Ok(_broDetailsService.GetBroDetails());
        }
    }
}
