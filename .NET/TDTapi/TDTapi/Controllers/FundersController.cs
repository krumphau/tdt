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
    [Route("funders")]
    public class FundersController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public FundersController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public string Post([FromBody] FunderModel funder)
        {
            Response.StatusCode = 201;
            string result = FunderService.CreateFunder(funder, dbConn);
            return "Posted " + result;
        }

        [HttpGet]
        public List<FunderModel> Get()
        {
            return FunderService.GetAllFunders(dbConn);
        }

        [Route("/funder/{id}")]
        [HttpGet]
        public FunderModel GetFunder([FromRoute] int id)
        {
            return FunderService.GetFunder(id, dbConn);
        }

        [Route("/funder/{id}")]
        [HttpDelete]
        public string DeleteFunder([FromRoute] int id)
        {
            return FunderService.DeleteFunder(id, dbConn);
        }

        [Route("/funder/{id}")]
        [HttpPut]
        public string UpdateFunder([FromRoute] int id, [FromBody] FunderModel funder)
        {
            return FunderService.UpdateFunder(funder, dbConn);
        }

        [Route("/projectfunder")]
        public ProjectFunderModel PostProjectFunder([FromBody] ProjectFunderModel projectFunder)
        {
            Response.StatusCode = 201;
            string result = ProjectFunderService.AddProjectFunder(projectFunder, dbConn);
            projectFunder.Id = Convert.ToInt32(result);
            return projectFunder;
        }

        [Route("/projectfunder/{id}")]
        [HttpDelete]
        public string DeleteProjectFunder([FromRoute] int id)
        {
            return ProjectFunderService.DeleteProjectFunder(id, dbConn);
        }

        [Route("/projectfunder/{projectid}")]
        [HttpGet]
        public List<ProjectFunderModel> GetFundersForProject([FromRoute] int projectid)
        {
            return ProjectFunderService.GetProjectFunders(projectid, dbConn);
        }
    }
}
