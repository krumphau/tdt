using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class StatusCodeService
    {
        public static string CreateStatusCode(StatusCodeModel statuscode, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@StatusCode", statuscode.StatusCode);
            spParams.Add("@StatusCodeDesc", statuscode.Description);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertStatusCode(@StatusCode, @StatusCodeDesc)", spParams);
        }

        public static List<StatusCodeModel> GetAllStatusCodes(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllProjectStatusCodes");
                List<StatusCodeModel> statuscodes = new List<StatusCodeModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    statuscodes.Add(dr.ToObject<StatusCodeModel>());
                }

                return statuscodes;
            }
            catch (Exception)
            {
                return new List<StatusCodeModel>();
            }
        }

        public static StatusCodeModel GetStatusCode(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetStatusCode(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<StatusCodeModel>();

            }
            catch (Exception)
            {
                return default(StatusCodeModel);
            }
        }

        public static string DeleteStatusCode(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteStatusCode(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateStatusCode(StatusCodeModel statuscode, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", statuscode.Id);
                spParams.Add("@StatusCode", statuscode.StatusCode);
                spParams.Add("@StatusCodeDesc", statuscode.Description);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateStatusCodes(@Id, @StatusCode, @StatusCodeDesc)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }
}
