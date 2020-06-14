using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class NGOService
    {
        public static string CreateNGO(NGOModel ngo, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", ngo.Name);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertNGO(@Name)", spParams);
        }

        public static List<NGOModel> GetAllNGOs(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllNGOs");
                List<NGOModel> ngos = new List<NGOModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ngos.Add(dr.ToObject<NGOModel>());
                }

                return ngos;
            }
            catch (Exception)
            {
                return new List<NGOModel>();
            }
        }

        public static NGOModel GetNGO(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetNGO(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<NGOModel>();

            }
            catch (Exception)
            {
                return default(NGOModel);
            }
        }

        public static string DeleteNGO(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteNGO(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateNGO(NGOModel ngo, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", ngo.Id);
                spParams.Add("@Name", ngo.Name);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateNGO(@Id, @Name)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }
}
