using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TDTapi.Models;
using TDTapi.Services;

namespace TDTapi.Controllers
{
    [EnableCors("MyPolicy")]
    [Authorize]
    [Route("ngos")]
    public class NGOsController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public NGOsController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public NGOModel Post([FromBody] NGOModel ngo)
        {
            Response.StatusCode = 201;
            string result = NGOService.CreateNGO(ngo, dbConn);
            ngo.Id = Convert.ToInt32(result);
            return ngo;
        }

        [HttpGet]
        public List<NGOModel> Get()
        {
            return NGOService.GetAllNGOs(dbConn);
        }

        [Route("/ngo/{id}")]
        [HttpGet]
        public NGOModel GetNGO([FromRoute] int id)
        {
            return NGOService.GetNGO(id, dbConn);
        }

        [Route("/ngo/{id}")]
        [HttpDelete]
        public string DeleteNGO([FromRoute] int id)
        {
            return NGOService.DeleteNGO(id, dbConn);
        }

        [Route("/ngo/{id}")]
        [HttpPut]
        public string UpdateNGO([FromRoute] int id, [FromBody] NGOModel ngo)
        {
            return NGOService.UpdateNGO(ngo, dbConn);
        }

        [Route("/projectngo")]
        public ProjectNGOModel PostProjectNGO([FromBody] ProjectNGOModel projectNGO)
        {
            Response.StatusCode = 201;
            string result = ProjectNGOService.AddProjectNGO(projectNGO, dbConn);
            projectNGO.Id = Convert.ToInt32(result);
            return projectNGO;
        }

        [Route("/projectngo/{id}")]
        [HttpDelete]
        public string DeleteProjectNGO([FromRoute] int id)
        {
            return ProjectNGOService.DeleteProjectNGO(id, dbConn);
        }

        [Route("/projectngo/{projectid}")]
        [HttpGet]
        public List<ProjectNGOModel> GetNGOsForProject([FromRoute] int projectid)
        {
            return ProjectNGOService.GetProjectNGOs(projectid, dbConn);
        }
    }
}
