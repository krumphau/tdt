using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectVisitService {

    public static string AddProjectVisit(ProjectVisitModel projectVisit, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectVisit.ProjectId);
            spParams.Add("@VisitStart", projectVisit.VisitStart);
            spParams.Add("@VisitEnd", projectVisit.VisitEnd);
            spParams.Add("@Visitor", projectVisit.Visitor);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddVisitToProject(@ProjectId, @VisitStart, @VisitEnd, @Visitor)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string DeleteProjectVisit(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveVisitFromProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static List<ProjectVisitModel> GetProjectVisits(object projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetVisitsForProject(@ProjectId)", spParams);
            List<ProjectVisitModel> projects = new List<ProjectVisitModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectVisitModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public static string UpdateProjectVisit(ProjectVisitModel projectVisit, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", projectVisit.Id);
            spParams.Add("@VisitStart", projectVisit.VisitStart);
            spParams.Add("@VisitEnd", projectVisit.VisitEnd);
            spParams.Add("@Visitor", projectVisit.Visitor);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateVisit(@Id, @VisitStart, @VisitEnd, @Visitor)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
}
