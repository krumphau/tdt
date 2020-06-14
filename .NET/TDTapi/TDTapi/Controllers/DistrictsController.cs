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
    [Route("districts")]
    public class DistrictsController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public DistrictsController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public DistrictModel Post([FromBody] DistrictModel district)
        {
            Response.StatusCode = 201;
            string result = DistrictService.CreateDistrict(district, dbConn);
            district.Id = Convert.ToInt32(result);
            return district;
        }

        [HttpGet]
        public List<DistrictModel> Get()
        {
            return DistrictService.GetAllDistricts(dbConn);
        }

        [Route("/district/{id}")]
        [HttpGet]
        public DistrictModel GetDistrict([FromRoute] int id)
        {
            return DistrictService.GetDistrict(id, dbConn);
        }

        [Route("/district/{id}")]
        [HttpDelete]
        public string DeleteDistrict([FromRoute] int id)
        {
            return DistrictService.DeleteDistrict(id, dbConn);
        }

        [Route("/district/{id}")]
        [HttpPut]
        public string UpdateDistrict([FromRoute] int id, [FromBody] DistrictModel district)
        {
            return DistrictService.UpdateDistrict(district, dbConn);
        }
    }
}
