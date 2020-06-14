using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectNGOService
{
    public static string AddProjectNGO(ProjectNGOModel projectNGO, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectNGO.ProjectId);
            spParams.Add("@NGOId", projectNGO.NGOId);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddNGOToProject(@ProjectId, @NGOId)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string DeleteProjectNGO(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveNGOFromProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static List<ProjectNGOModel> GetProjectNGOs(object projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetNGOsForProject(@ProjectId)", spParams);
            List<ProjectNGOModel> projects = new List<ProjectNGOModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectNGOModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }
}
