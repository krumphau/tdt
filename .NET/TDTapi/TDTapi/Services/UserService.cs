using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;

namespace TDTapi.Services
{
    public class UserService
    {
        public static UserModel GetUser(string email, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Email", email);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetUser(@Email)", spParams);
                return ds.Tables[0].Rows[0].ToObject<UserModel>();

            }
            catch (Exception)
            {
                return default(UserModel);
            }
        }
    }
}
