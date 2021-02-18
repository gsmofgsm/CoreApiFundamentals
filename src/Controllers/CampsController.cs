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
        public object Get()
        {
            return new { Moniker = "ATL2018", Name = "Atlanta Code Camp" }; // anonymous type
        }
    }
}
