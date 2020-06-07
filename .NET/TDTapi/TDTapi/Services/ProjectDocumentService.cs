using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;
using System.IO;

public static class ProjectDocumentService
{

    public static string AddProjectDocument(ProjectDocumentModel projectDocument, string connstring) {
        try 
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectDocument.ProjectId);
            spParams.Add("@DocName", projectDocument.DocName);
            spParams.Add("@FilePath", projectDocument.FilePath);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_AddDocumentToProject(@ProjectId, @DocName, @FilePath)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
    
    public static string DeleteProjectDocument(int id, string connstring) {
        try {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveDocumentFromProject(@Id)", spParams);
        } catch (Exception) {
            return ("An error occurred");
        }
    }
    
    public static List<ProjectDocumentModel> GetProjectDocs(int projectid, string connstring) {
        try {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetDocsForProject(@ProjectId)", spParams);
            List<ProjectDocumentModel> projects = new List<ProjectDocumentModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectDocumentModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }
    
    public async static Task<List<string>> ListStorage()
    {
        S3Util s3 = new S3Util();
        List<string> result = await s3.ListBucketContents();
        return result;
    }
    
    public static string UploadFile(Stream file, string fileName, string projectId) 
    {
        S3Util s3 = new S3Util();
        s3.UploadFile(file, projectId + '/' + fileName);
        return projectId + '/' + fileName;
    }
    
    public async static Task<byte[]> DownloadFile(string filename) {

        S3Util s3 = new S3Util();

        string filePath = await s3.DownloadFile(filename);

        return File.ReadAllBytes(filePath);
        //TODO: should return filePath or stream?

        //if (request.method == "GET") {
        //    var output = download_file(filename, BUCKET);
        //    return send_file(output, as_attachment: true);
        //}
    }
    
    
    public static void DownloadFromFolder(object foldername, object filename) {
        //TODO: do I need this method

        //if (request.method == "GET") {
        //    var output = download_file_from_folder(filename, foldername, BUCKET);
        //    return send_file(output, as_attachment: true);
        //}
    }
}
