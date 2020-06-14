using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class CategoryService
    {
        public static string CreateCategory(CategoryModel category, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", category.CategoryName);
            spParams.Add("@HighLevel", category.HighLevelCategory);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertCategory(@Name, @HighLevel)", spParams);
        }

        public static List<CategoryModel> GetAllCategories(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllCategories");
                List<CategoryModel> categorys = new List<CategoryModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    categorys.Add(dr.ToObject<CategoryModel>());
                }

                return categorys;
            }
            catch (Exception)
            {
                return new List<CategoryModel>();
            }
        }

        public static CategoryModel GetCategory(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetCategory(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<CategoryModel>();

            }
            catch (Exception)
            {
                return default(CategoryModel);
            }
        }

        public static string DeleteCategory(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteCategory(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateCategory(CategoryModel category, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", category.Id);
                spParams.Add("@Name", category.CategoryName);
                spParams.Add("@HighLevel", category.HighLevelCategory);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateCategory(@Id, @Name, @HighLevel)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }
}
