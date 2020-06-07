using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

public static class ProjectOfficerService
{
    public static string CreateProjectOfficer(ProjectOfficerModel projectofficer, string connstring)
    {
        Dictionary<string, object> spParams = new Dictionary<string, object>();
        spParams.Add("@FirstName", projectofficer.FirstName);
        spParams.Add("@LastName", projectofficer.LastName);
        spParams.Add("@Tel", projectofficer.Tel);
        spParams.Add("@Mobile", projectofficer.Mobile);
        spParams.Add("@Address1", projectofficer.Address1);
        spParams.Add("@Address2", projectofficer.Address2);
        spParams.Add("@Address3", projectofficer.Address3);
        spParams.Add("@Town", projectofficer.Town);
        spParams.Add("@County", projectofficer.County);
        spParams.Add("@PostCode", projectofficer.PostCode);
        spParams.Add("@Info", projectofficer.Info);
        spParams.Add("@Email", projectofficer.Email);
        return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_InsertProjectOfficer(@FirstName, @LastName, @Tel, @Mobile, @Address1, @Address2, @Address3, @Town, @County, @PostCode, @Info, @Email)", spParams);
    }

    public static List<ProjectOfficerModel> GetAllProjectOfficers(string connstring)
    {
        try
        {
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllProjectOfficers");
            List<ProjectOfficerModel> projectofficers = new List<ProjectOfficerModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projectofficers.Add(dr.ToObject<ProjectOfficerModel>());
            }

            return projectofficers;
        }
        catch (Exception)
        {
            return new List<ProjectOfficerModel>();
        }
    }

    public static ProjectOfficerModel GetProjectOfficer(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetProjectOfficer(@Id)", spParams);
            return ds.Tables[0].Rows[0].ToObject<ProjectOfficerModel>();

        }
        catch (Exception)
        {
            return default(ProjectOfficerModel);
        }
    }

    public static string DeleteProjectOfficer(object id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteProjectOfficer(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string UpdateProjectOfficer(ProjectOfficerModel projectofficer, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", projectofficer.Id);
            spParams.Add("@FirstName", projectofficer.FirstName);
            spParams.Add("@LastName", projectofficer.LastName);
            spParams.Add("@Tel", projectofficer.Tel);
            spParams.Add("@Mobile", projectofficer.Mobile);
            spParams.Add("@Address1", projectofficer.Address1);
            spParams.Add("@Address2", projectofficer.Address2);
            spParams.Add("@Address3", projectofficer.Address3);
            spParams.Add("@Town", projectofficer.Town);
            spParams.Add("@County", projectofficer.County);
            spParams.Add("@PostCode", projectofficer.PostCode);
            spParams.Add("@Info", projectofficer.Info);
            spParams.Add("@Email", projectofficer.Email);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateProjectOfficer(@Id, @FirstName, @LastName, @Tel, @Mobile, @Address1, @Address2, @Address3, @Town, @County, @PostCode, @Info, @Email)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
}
