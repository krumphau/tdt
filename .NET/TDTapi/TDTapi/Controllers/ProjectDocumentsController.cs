using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using TDTapi.Models;
using TDTapi.Services;

namespace TDTapi.Controllers
{
    [EnableCors("MyPolicy")]
    [Authorize]
    [Route("/projectdocument")]
    [ApiController]
    public class ProjectDocumentsController : ControllerBase
    {
        IConfiguration _config;
        string dbConn;
        public ProjectDocumentsController(IConfiguration configuration)
        {
            this._config = configuration;
            dbConn = _config.GetValue<string>("DBConnection");
        }

        [Route("/projectdocument")]
        [HttpPost]
        public ProjectDocumentModel Post([FromBody] ProjectDocumentModel projectDoc)
        {
            Response.StatusCode = 201;

            string result = ProjectDocumentService.AddProjectDocument(projectDoc, dbConn);
            projectDoc.Id = Convert.ToInt32(result);
            return projectDoc;
        }

        [Route("/projectdocument/{id}")]
        [HttpDelete]
        public string Delete([FromRoute] int id)
        {
            return ProjectDocumentService.DeleteProjectDocument(id, dbConn);
        }

        [Route("/projectdocument/{projectId}")]
        [HttpGet]
        public List<ProjectDocumentModel> Get([FromRoute] int projectId)
        {
            return ProjectDocumentService.GetProjectDocs(projectId, dbConn);
        }

        [Route("/upload/{projectId}")]
        [HttpPost]
        public string UploadFile(IFormFile file, [FromRoute] int projectId)
        {
            return ProjectDocumentService.UploadFile(file.OpenReadStream(), file.FileName, projectId.ToString());
        }

        [Route("/storage")]
        [HttpGet]
        public List<string> GetBucketContents()
        {
            return ProjectDocumentService.ListStorage().Result;
        }

        [Route("/download/{filename}")]
        public IActionResult DownloadFile([FromRoute] string filename)
        {
            byte[] fileBytes = ProjectDocumentService.DownloadFile(filename).Result;

            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(filename, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return new FileContentResult(fileBytes, contentType);
        }

        [Route("/link/{foldername}/{filename}")]
        public string GetTempLink([FromRoute] string foldername, [FromRoute] string filename)
        {
            return ProjectDocumentService.GetTempLink(foldername + '/' + filename);
        }

        [Route("/download/{foldername}/{filename}")]
        public IActionResult DownloadFolderFile([FromRoute] string foldername, [FromRoute] string filename)
        {
            return DownloadFile(foldername + '/' + filename);
        }
    }
}
