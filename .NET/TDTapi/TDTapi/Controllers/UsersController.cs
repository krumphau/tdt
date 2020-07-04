using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TDTapi.Models;
using TDTapi.Services;

namespace TDTapi.Controllers
{
    [EnableCors("MyPolicy")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public UsersController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [Route("/user/{email}")]
        [HttpGet]
        public UserModel GetUser([FromRoute] string email)
        {
            return UserService.GetUser(email, dbConn);
        }
    }
}
