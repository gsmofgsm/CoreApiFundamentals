﻿using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Http;
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
        private readonly ICampRepository _repository;

        // Attribute for controller CampsController:
        // it could be[Route("api/camps")],
        // but could be not hard coded:
        // [Route("api/[controller]")], then the placeholder will take what is in the class name and before 'controller'

        // base class ControllerBase is specific for api's

        public CampsController(ICampRepository repository)
        {
            _repository = repository;
        }

        // the action, the method in the controller class
        // is the actual endpoint
        [HttpGet]
        public async Task<IActionResult> GetCamps()
        {
            try
            {
                var results = await _repository.GetAllCampsAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
