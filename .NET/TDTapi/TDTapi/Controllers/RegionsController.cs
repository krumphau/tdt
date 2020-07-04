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
    [Route("regions")]
    public class RegionsController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public RegionsController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public RegionModel Post([FromBody] RegionModel region)
        {
            Response.StatusCode = 201;
            string result = RegionService.CreateRegion(region, dbConn);
            region.Id = Convert.ToInt32(result);
            return region;
        }

        [HttpGet]
        public List<RegionModel> Get()
        {
            return RegionService.GetAllRegions(dbConn);
        }

        [Route("/region/{id}")]
        [HttpGet]
        public RegionModel GetRegion([FromRoute] int id)
        {
            return RegionService.GetRegion(id, dbConn);
        }

        [Route("/region/{id}")]
        [HttpDelete]
        public string DeleteRegion([FromRoute] int id)
        {
            return RegionService.DeleteRegion(id, dbConn);
        }

        [Route("/region/{id}")]
        [HttpPut]
        public string UpdateRegion([FromRoute] int id, [FromBody] RegionModel region)
        {
            return RegionService.UpdateRegion(region, dbConn);
        }
    }
}
