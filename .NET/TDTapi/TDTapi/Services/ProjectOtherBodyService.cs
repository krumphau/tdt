using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectOtherBodyService
{
    public static string AddProjectOtherBody(ProjectOtherBodyModel projectOtherBody, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectOtherBody.ProjectId);
            spParams.Add("@OtherBodyId", projectOtherBody.OtherBodyId);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_AddOtherBodyToProject(@ProjectId, @OtherBodyId)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string DeleteProjectOtherBody(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveOtherBodyFromProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static List<ProjectOtherBodyModel> GetProjectOtherBodies(object projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetOtherBodiesForProject(@ProjectId)", spParams);
            List<ProjectOtherBodyModel> projects = new List<ProjectOtherBodyModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectOtherBodyModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }
}
