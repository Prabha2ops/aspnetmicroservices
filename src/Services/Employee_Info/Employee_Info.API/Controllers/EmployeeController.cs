using Employee_Info.API.Entities;
using Employee_Info.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Employee_Info.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IPersonRepositary _repositary ;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IPersonRepositary repositary, ILogger<EmployeeController> logger)
        {
            _repositary = repositary ?? throw new ArgumentNullException(nameof(repositary)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons(String search_email_id)
        {
            if (string.IsNullOrEmpty(search_email_id))
            {
                return BadRequest("Missing / invalid arguments.");
            }

            var (persons, context) = await _repositary.GetPerson(search_email_id);
            return Ok(new Result(persons, context));
        }


    }
}
