using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class FunderService
    {
        public static string CreateFunder(FunderModel funder, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Name", funder.Name);
            spParams.Add("@Address1", funder.Address1);
            spParams.Add("@Address2", funder.Address2);
            spParams.Add("@Address3", funder.Address3);
            spParams.Add("@Town", funder.Town);
            spParams.Add("@County", funder.County);
            spParams.Add("@PostCode", funder.PostCode);
            spParams.Add("@Tel", funder.Tel);
            spParams.Add("@MainContact", funder.MainContact);
            spParams.Add("@Amount", funder.Amount);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertFunder(@Name, @Address1, @Address2, @Address3, @Town, @County, @PostCode, @Tel, @MainContact, @Amount)", spParams);
        }

        public static List<FunderModel> GetAllFunders(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllFunders");
                List<FunderModel> funders = new List<FunderModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    funders.Add(dr.ToObject<FunderModel>());
                }

                return funders;
            }
            catch (Exception)
            {
                return new List<FunderModel>();
            }
        }

        public static FunderModel GetFunder(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetFunder(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<FunderModel>();

            }
            catch (Exception)
            {
                return default(FunderModel);
            }
        }

        public static string DeleteFunder(object id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteFunder(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateFunder(FunderModel funder, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", funder.Id);
                spParams.Add("@Name", funder.Name);
                spParams.Add("@Address1", funder.Address1);
                spParams.Add("@Address2", funder.Address2);
                spParams.Add("@Address3", funder.Address3);
                spParams.Add("@Town", funder.Town);
                spParams.Add("@County", funder.County);
                spParams.Add("@PostCode", funder.PostCode);
                spParams.Add("@Tel", funder.Tel);
                spParams.Add("@MainContact", funder.MainContact);
                spParams.Add("@Amount", funder.Amount);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateFunder(@Id, @Name, @Address1, @Address2, @Address3, @Town, @County, @PostCode, @Tel, @MainContact, @Amount)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }
    }
}
