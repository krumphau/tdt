using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectRelatedProjectService
{

    public static string DeleteRelatedProject(object id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveRelatedProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
    public static List<RelatedProjectModel> GetRelatedProjects(int projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetRelatedProjects(@ProjectId)", spParams);
            List<RelatedProjectModel> projects = new List<RelatedProjectModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<RelatedProjectModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public static string AddRelatedProject(RelatedProjectModel relatedProject, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", relatedProject.ProjectId);
            spParams.Add("@RelationshipKey", relatedProject.RelationshipKey);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddRelatedProject(@ProjectId, @RelationshipKey)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
}
