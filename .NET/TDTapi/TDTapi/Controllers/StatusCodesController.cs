using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TDTapi.Models;
using TDTapi.Services;

namespace TDTapi.Controllers
{
    [Authorize]
    [Route("statuscodes")]
    public class StatusCodesController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public StatusCodesController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public string Post([FromBody] StatusCodeModel statuscode)
        {
            Response.StatusCode = 201;
            string result = StatusCodeService.CreateStatusCode(statuscode, dbConn);
            return "Posted " + result;
        }

        [HttpGet]
        public List<StatusCodeModel> Get()
        {
            return StatusCodeService.GetAllStatusCodes(dbConn);
        }

        [Route("/statuscode/{id}")]
        [HttpGet]
        public StatusCodeModel GetStatusCode([FromRoute] int id)
        {
            return StatusCodeService.GetStatusCode(id, dbConn);
        }

        [Route("/statuscode/{id}")]
        [HttpDelete]
        public string DeleteStatusCode([FromRoute] int id)
        {
            return StatusCodeService.DeleteStatusCode(id, dbConn);
        }

        [Route("/statuscode/{id}")]
        [HttpPut]
        public string UpdateStatusCode([FromRoute] int id, [FromBody] StatusCodeModel statuscode)
        {
            return StatusCodeService.UpdateStatusCode(statuscode, dbConn);
        }
    }
}
