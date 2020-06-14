using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;
public static class ProjectCategoryService
{    
    public static string AddProjectCategory(ProjectCategoryModel projectCategory, string connstring) {
        try {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectCategory.ProjectId);
            spParams.Add("@CategoryId", projectCategory.CategoryId);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddCategoryToProject(@ProjectId, @CategoryId)", spParams);
        } catch (Exception) {
            return ("An error occurred");
        }
    }
    
    public static string DeleteProjectCategory(int id, string connstring) {
        try 
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemoveCategoryFromProject(@Id)", spParams);
        } catch (Exception) {
            return ("An error occurred");
        }
    }

    public static List<ProjectCategoryModel> GetProjectCategories(object projectid, string connstring) {
        try 
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetCategoriesForProject(@ProjectId)", spParams);
            List<ProjectCategoryModel> projects = new List<ProjectCategoryModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectCategoryModel>());
            }
            return projects;
        } catch (Exception) {
            return default;
        }
    }
}
