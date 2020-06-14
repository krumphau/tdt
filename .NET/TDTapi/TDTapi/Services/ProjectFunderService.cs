using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectFunderService
{
    public static string AddProjectFunder(ProjectFunderModel projectFunder, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectFunder.ProjectId);
            spParams.Add("@FunderId", projectFunder.FunderId);
            spParams.Add("@AmountFunded", projectFunder.AmountFunded);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddFunderToProject(@ProjectId, @FunderId, @AmountFunded)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string DeleteProjectFunder(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveFunderFromProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static List<ProjectFunderModel> GetProjectFunders(object projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetFundersForProject(@ProjectId)", spParams);
            List<ProjectFunderModel> projects = new List<ProjectFunderModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectFunderModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }
}
