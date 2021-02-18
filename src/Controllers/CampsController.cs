using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        // Attribute for controller CampsController:
        // it could be[Route("api/camps")],
        // but could be not hard coded:
        // [Route("api/[controller]")], then the placeholder will take what is in the class name and before 'controller'

        // base class ControllerBase is specific for api's

        // the action, the method in the controller class
        // is the actual endpoint
        [HttpGet]
        public IActionResult GetCamps()
        {
            if (false) return BadRequest("Bad stuff happens");
            return Ok(new { Moniker = "ATL2018", Name = "Atlanta Code Camp" }); // anonymous type
        }
    }
}
