using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public static class RegionService
    {
        public static string CreateRegion(RegionModel region, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", region.Name);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_InsertRegion(@Name)", spParams);
        }

        public static List<RegionModel> GetAllRegions(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllRegions");
                List<RegionModel> regions = new List<RegionModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    regions.Add(dr.ToObject<RegionModel>());
                }

                return regions;
            }
            catch (Exception)
            {
                return new List<RegionModel>();
            }
        }

        public static RegionModel GetRegion(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetRegion(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<RegionModel>();

            }
            catch (Exception)
            {
                return default(RegionModel);
            }
        }

        public static string DeleteRegion(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteRegion(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateRegion(RegionModel region, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", region.Id);
                spParams.Add("@Name", region.Name);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateRegion(@Id, @Name)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }

}
