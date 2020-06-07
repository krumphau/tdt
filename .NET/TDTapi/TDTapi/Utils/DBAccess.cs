using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TDTapi.Utils
{
    public static class DBAccess
    {
        public static DataSet ExecuteDataSet(string connString, string spName, Dictionary<string, object> spParams = null)
        {
            DataSet ds = new DataSet();


            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = spName;
            if (spParams != null)
            {
                foreach (var param in spParams)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            return ds;
        }

        public static string ExecuteSQLNonQuery(string connString, string spName, Dictionary<string, object> spParams = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = spName;

                    if (spParams != null)
                    {
                        foreach (var param in spParams)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    var result = cmd.ExecuteNonQuery();

                    return result.ToString();
                }
            }
        }

        public static string ExecuteSQLScalar(string connString, string spName, Dictionary<string, object> spParams = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = spName;

                    if (spParams != null)
                    {
                        foreach (var param in spParams)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    var result = cmd.ExecuteScalar();

                    return result.ToString();
                }
            }
        }
    }
}
