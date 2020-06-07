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
    [Route("projects")]
    public class ProjectsController : Controller
    {
        IConfiguration _config;
        string dbConn;
        public ProjectsController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }
        [HttpGet]
        public List<ProjectModel> Get()
        {
            return ProjectService.GetProjects(dbConn);
        }

        [HttpPost]
        public string Post([FromBody]ProjectModel project)
        {
            Response.StatusCode = 201;
            
            string result = ProjectService.CreateProject(project, dbConn);
            return "Posted " + result;
        }

        [Route("/project/{id}/metadata")]
        [HttpPut]
        public string PutMetadata([FromRoute] int id, [FromBody] ProjectMetadataModel projectMeta)
        {
            projectMeta.ProjectId = id;
            return ProjectService.UpdateProjectMetadata(projectMeta, dbConn);
        }

        [Route("/project/{id}")]
        [HttpPut]
        public string PutProject([FromRoute] int id, [FromBody]ProjectModel project)
        {
            project.Id = id;
            return ProjectService.UpdateProject(project, dbConn);
        }

        [Route("/project/{id}/notes")]
        [HttpPut]
        public string PutProjectNotes([FromRoute] int id, [FromBody] ProjectNotesModel projectNotes)
        {
            projectNotes.ProjectId = id;
            return ProjectService.UpdateProjectNotes(projectNotes, dbConn);
        }


        [Route("/project/{id}")]
        [HttpDelete]
        public string DeleteProject([FromRoute] int id)
        {
            return ProjectService.DeleteProject(id, dbConn);
        }

        [Route("/project/{id}")]
        [HttpGet]
        public ProjectModel GetProject([FromRoute] int id)
        {
            return ProjectService.GetProject(id, dbConn);
        }

        [Route("/search")]
        [HttpPost]
        public List<ProjectModel> SearchProjects([FromBody] SearchModel criteria)
        {
            return ProjectService.SearchProjects(criteria, dbConn);
        }

        [Route("/relatedproject")]
        [HttpPost]
        public string AddRelatedProject([FromBody] RelatedProjectModel project)
        {
            Response.StatusCode = 201;

            string result = ProjectRelatedProjectService.AddRelatedProject(project, dbConn);
            return "Posted " + result;
        }

        [Route("/relatedproject/{id}")]
        [HttpDelete]
        public string DeleteRelatedProject([FromRoute] int id)
        {
            return ProjectRelatedProjectService.DeleteRelatedProject(id, dbConn);
        }

        [Route("/relatedproject/{projectId}")]
        [HttpGet]
        public List<ProjectModel> GetRelatedProjects([FromRoute] int projectId)
        {
            return ProjectRelatedProjectService.GetRelatedProjects(projectId, dbConn);
        }

        [Route("/projectvisit")]
        [HttpPost]
        public string AddProjectVisit([FromBody] ProjectVisitModel project)
        {
            Response.StatusCode = 201;

            string result = ProjectVisitService.AddProjectVisit(project, dbConn);
            return "Posted " + result;
        }

        [Route("/projectvisit/{id}")]
        [HttpPut]
        public string UpdateProjectVisit([FromRoute] int id, [FromBody] ProjectVisitModel project)
        {
            project.Id = id;
            return ProjectVisitService.UpdateProjectVisit(project, dbConn);
        }

        [Route("/projectvisit/{id}")]
        [HttpDelete]
        public string DeleteProjectVisit([FromRoute] int id)
        {
            return ProjectVisitService.DeleteProjectVisit(id, dbConn);
        }

        [Route("/projectvisit/{projectid}")]
        [HttpGet]
        public List<ProjectVisitModel> GetProjectVisits([FromRoute] int projectId)
        {
            return ProjectVisitService.GetProjectVisits(projectId, dbConn);
        }

        [Route("/purchaseditem")]
        [HttpPost]
        public string AddProjectPurchasedItem([FromBody] ProjectPurchasedItemModel project)
        {
            Response.StatusCode = 201;

            string result = ProjectPurchasedItemService.AddProjectPurchasedItem(project, dbConn);
            return "Posted " + result;
        }

        [Route("/purchaseditem/{id}")] 
                [HttpPut]
        public string UpdateProjectPurchasedItem([FromRoute] int id, [FromBody] ProjectPurchasedItemModel project)
        {
            project.Id = id;
            return ProjectPurchasedItemService.UpdateProjectPurchasedItem(project, dbConn);
        }

        [Route("/purchaseditems/{id}")]
                [HttpDelete]
        public string DeleteProjectPurchasedItem([FromRoute] int id)
        {
            return ProjectPurchasedItemService.DeleteProjectPurchasedItem(id, dbConn);
        }

        [Route("/purchaseditems/{projectid}")] 
                [HttpGet]
        public List<ProjectPurchasedItemModel> GetProjectPurchasedItems([FromRoute] int projectId)
        {
            return ProjectPurchasedItemService.GetProjectPurchasedItems(projectId, dbConn);
        }

        //[Route("/relatedproject")] 
        //        [HttpPost]
        //public string AddProjectRelatedProject([FromBody] RelatedProjectModel project)
        //{
        //    Response.StatusCode = 201;

        //    string result = ProjectRelatedProjectService.AddRelatedProject(project, dbConn);
        //    return "Posted " + result;
        //}

        //[Route("/relatedproject/{id}")] 
        //        [HttpDelete]
        //public string DeleteProjectRelatedProject([FromRoute] int id)
        //{
        //    return ProjectRelatedProjectService.DeleteRelatedProject(id, dbConn);
        //}

        //[Route("/relatedproject/{projectid}")] 
        //        [HttpGet]
        //public List<ProjectModel> GetProjectRelatedProjects([FromRoute] int projectId)
        //{
        //    return ProjectRelatedProjectService.GetRelatedProjects(projectId, dbConn);
        //}
    }
}
