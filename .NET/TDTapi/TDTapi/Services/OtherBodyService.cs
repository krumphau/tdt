using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class OtherBodyService
    {
        public static string CreateOtherBody(OtherBodyModel ngo, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", ngo.Name);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertOtherBody(@Name)", spParams);
        }

        public static List<OtherBodyModel> GetAllOtherBodies(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllOtherBodies");
                List<OtherBodyModel> otherbodies = new List<OtherBodyModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    otherbodies.Add(dr.ToObject<OtherBodyModel>());
                }

                return otherbodies;
            }
            catch (Exception)
            {
                return new List<OtherBodyModel>();
            }
        }

        public static OtherBodyModel GetOtherBody(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetOtherBody(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<OtherBodyModel>();

            }
            catch (Exception)
            {
                return default(OtherBodyModel);
            }
        }

        public static string DeleteOtherBody(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteOtherBody(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateOtherBody(OtherBodyModel ngo, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", ngo.Id);
                spParams.Add("@Name", ngo.Name);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateOtherBody(@Id, @Name)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }
}
