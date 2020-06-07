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
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public CategoriesController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [HttpPost]
        public string Post([FromBody] CategoryModel category)
        {
            Response.StatusCode = 201;
            string result = CategoryService.CreateCategory(category, dbConn);
            return "Posted " + result;
        }

        [HttpGet]
        public List<CategoryModel> Get()
        {
            return CategoryService.GetAllCategories(dbConn);
        }

        [Route("/category/{id}")]
        [HttpGet]
        public CategoryModel GetCategory([FromRoute] int id)
        {
            return CategoryService.GetCategory(id, dbConn);
        }

        [Route("/category/{id}")]
        [HttpDelete]
        public string DeleteCategory([FromRoute] int id)
        {
            return CategoryService.DeleteCategory(id, dbConn);
        }

        [Route("/category/{id}")]
        [HttpPut]
        public string UpdateCategory([FromRoute] int id, [FromBody] CategoryModel category)
        {
            return CategoryService.UpdateCategory(category, dbConn);
        }

        [Route("/projectcategory")]
        public string PostProjectCategory([FromBody] ProjectCategoryModel projectCategory)
        {
            Response.StatusCode = 201;
            string result = ProjectCategoryService.AddProjectCategory(projectCategory, dbConn);
            return "Posted " + result;
        }

        [Route("/projectcategory/{id}")]
        [HttpDelete]
        public string DeleteProjectCategory([FromRoute] int id)
        {
            return ProjectCategoryService.DeleteProjectCategory(id, dbConn);
        }

        [Route("/projectcategory/{projectid}")]
        [HttpGet]
        public List<ProjectCategoryModel> GetCategoriesForProject([FromRoute] int projectid)
        {
            return ProjectCategoryService.GetProjectCategories(projectid, dbConn);
        }
    }
}

