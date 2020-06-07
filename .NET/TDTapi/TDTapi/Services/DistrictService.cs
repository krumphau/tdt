using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public static class DistrictService
    {
        public static string CreateDistrict(DistrictModel district, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", district.Name);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_InsertDistrict(@Name)", spParams);
        }

        public static List<DistrictModel> GetAllDistricts(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllDistricts");
                List<DistrictModel> districts = new List<DistrictModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    districts.Add(dr.ToObject<DistrictModel>());
                }

                return districts;
            }
            catch (Exception)
            {
                return new List<DistrictModel>();
            }
        }

        public static DistrictModel GetDistrict(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetDistrict(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<DistrictModel>();

            }
            catch (Exception)
            {
                return default(DistrictModel);
            }
        }

        public static string DeleteDistrict(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteDistrict(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateDistrict(DistrictModel district, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", district.Id);
                spParams.Add("@Name", district.Name);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateDistrict(@Id, @Name)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }

}
