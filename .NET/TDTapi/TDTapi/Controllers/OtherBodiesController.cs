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
    [Route("otherbodies")]
    public class OtherBodiesController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public OtherBodiesController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public string Post([FromBody] OtherBodyModel otherbody)
        {
            Response.StatusCode = 201;
            string result = OtherBodyService.CreateOtherBody(otherbody, dbConn);
            return "Posted " + result;
        }

        [HttpGet]
        public List<OtherBodyModel> Get()
        {
            return OtherBodyService.GetAllOtherBodies(dbConn);
        }

        [Route("/otherbody/{id}")]
        [HttpGet]
        public OtherBodyModel GetOtherBody([FromRoute] int id)
        {
            return OtherBodyService.GetOtherBody(id, dbConn);
        }

        [Route("/otherbody/{id}")]
        [HttpDelete]
        public string DeleteOtherBody([FromRoute] int id)
        {
            return OtherBodyService.DeleteOtherBody(id, dbConn);
        }

        [Route("/otherbody/{id}")]
        [HttpPut]
        public string UpdateOtherBody([FromRoute] int id, [FromBody] OtherBodyModel otherbody)
        {
            return OtherBodyService.UpdateOtherBody(otherbody, dbConn);
        }

        [Route("/projectotherbody")]
        public string PostProjectOtherBody([FromBody] ProjectOtherBodyModel projectOtherBody)
        {
            Response.StatusCode = 201;
            string result = ProjectOtherBodyService.AddProjectOtherBody(projectOtherBody, dbConn);
            return "Posted " + result;
        }

        [Route("/projectotherbody/{id}")]
        [HttpDelete]
        public string DeleteProjectOtherBody([FromRoute] int id)
        {
            return ProjectOtherBodyService.DeleteProjectOtherBody(id, dbConn);
        }

        [Route("/projectotherbody/{projectid}")]
        [HttpGet]
        public List<ProjectOtherBodyModel> GetOtherBodiesForProject([FromRoute] int projectid)
        {
            return ProjectOtherBodyService.GetProjectOtherBodies(projectid, dbConn);
        }
    }
}

