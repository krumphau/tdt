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
    [Route("projectofficers")]
    public class ProjectOfficersController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public ProjectOfficersController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public ProjectOfficerModel Post([FromBody] ProjectOfficerModel projectofficer)
        {
            Response.StatusCode = 201;
            string result = ProjectOfficerService.CreateProjectOfficer(projectofficer, dbConn);
            projectofficer.Id = Convert.ToInt32(result);
            return projectofficer;
        }

        [HttpGet]
        public List<ProjectOfficerModel> Get()
        {
            return ProjectOfficerService.GetAllProjectOfficers(dbConn);
        }

        [Route("/projectofficer/{id}")]
        [HttpGet]
        public ProjectOfficerModel GetProjectOfficer([FromRoute] int id)
        {
            return ProjectOfficerService.GetProjectOfficer(id, dbConn);
        }

        [Route("/projectofficer/{id}")]
        [HttpDelete]
        public string DeleteProjectOfficer([FromRoute] int id)
        {
            return ProjectOfficerService.DeleteProjectOfficer(id, dbConn);
        }

        [Route("/projectofficer/{id}")]
        [HttpPut]
        public string UpdateProjectOfficer([FromRoute] int id, [FromBody] ProjectOfficerModel projectofficer)
        {
            return ProjectOfficerService.UpdateProjectOfficer(projectofficer, dbConn);
        }
    }
}
