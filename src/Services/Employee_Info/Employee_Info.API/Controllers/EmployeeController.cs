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
        private readonly IPersonRepositary _personrepositary;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IPersonRepositary personrepositary, ILogger<EmployeeController> logger)
        {
            _personrepositary = personrepositary ?? throw new ArgumentNullException(nameof(personrepositary));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        // GET api/Employee/{All info}
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons(String search_email_id)
        {
            if (string.IsNullOrEmpty(search_email_id))
            {
                return BadRequest("Missing / invalid arguments.");
            }

            var (persons, context) = await _personrepositary.GetPerson(search_email_id);
            return Ok(new Result(persons, context));
        }


        // POST api/Employee/{Create_all_info}
        [HttpPost("Create_all_Info")]
        public async Task<ActionResult<bool>> CreatePerson(string create_id, string create_employee_id,
            string create_first_name, string create_last_name, string create_mobile_no, string create_email_id,
            string create_org_unit, string create_org_team, string create_org_role, string create_location)
        {
            if (create_email_id == null)
            {
                return BadRequest();
            }

            var result = await _personrepositary.CreatePerson(create_id, create_employee_id,
            create_first_name, create_last_name, create_mobile_no, create_email_id,
            create_org_unit, create_org_team, create_org_role, create_location);


            return Ok();


        }




        // PUT api/Employee/{Update_all_info}
        [HttpPut("Update_all_Info")]
        public async Task<ActionResult<bool>> UpdatePerson(string update_id, string update_employee_id,
            string update_first_name, string update_last_name, string update_mobile_no, string update_email_id,
            string update_org_unit, string update_org_team, string update_org_role, string update_location)
        {
            if (update_email_id == null)
            {
                return BadRequest();
            }

            var result = await _personrepositary.UpdatePerson(update_id, update_employee_id,
            update_first_name, update_last_name, update_mobile_no,  update_email_id,
            update_org_unit, update_org_team, update_org_role, update_location);


            return Ok();

            
        }

        // PUT api/Employee/{Update_Name}
        [HttpPut("Update_Name")]
        public async Task<ActionResult<bool>> UpdatePersonName(string update_first_name, string update_last_name, string update_email_id)
        {
            if (update_email_id == null)
            {
                return BadRequest();
            }

            var result = await _personrepositary.UpdatePersonName(update_first_name, update_last_name, update_email_id);


            return Ok();


        }

        // DELETE api/Employee/{Delete_Name}
        [HttpDelete("Delete_Name")]
        public async Task<ActionResult<bool>> DeletePerson(string deleteby_email_id)
        {
            if (deleteby_email_id == null)
            {
                return BadRequest();
            }

            var result = await _personrepositary.DeletePerson(deleteby_email_id);


            return Ok();


        }








    }
}
