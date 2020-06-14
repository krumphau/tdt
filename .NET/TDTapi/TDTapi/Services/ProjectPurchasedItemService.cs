using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using System.Data;
public static class ProjectPurchasedItemService
{
    public static string AddProjectPurchasedItem(ProjectPurchasedItemModel projectPurchasedItem, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectPurchasedItem.ProjectId);
            spParams.Add("@PurchasedItem", projectPurchasedItem.PurchasedItem);
            spParams.Add("@DatePurchased", projectPurchasedItem.DatePurchased);
            spParams.Add("@ItemCost", projectPurchasedItem.ItemCost);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_AddPurchasedItemToProject(@ProjectId, @PurchasedItem, @DatePurchased, @ItemCost)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static string DeleteProjectPurchasedItem(int id, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", id);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_RemovePurchasedItemFromProject(@Id)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }

    public static List<ProjectPurchasedItemModel> GetProjectPurchasedItems(object projectid, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectId", projectid);
            DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetPurchasedItemsForProject(@ProjectId)", spParams);
            List<ProjectPurchasedItemModel> projects = new List<ProjectPurchasedItemModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                projects.Add(dr.ToObject<ProjectPurchasedItemModel>());
            }
            return projects;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public static string UpdateProjectPurchasedItem(ProjectPurchasedItemModel projectPurchasedItem, string connstring)
    {
        try
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@Id", projectPurchasedItem.Id);
            spParams.Add("@PurchasedItem", projectPurchasedItem.PurchasedItem);
            spParams.Add("@DatePurchased", projectPurchasedItem.DatePurchased);
            spParams.Add("@ItemCost", projectPurchasedItem.ItemCost);
            return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdatePurchasedItem(@Id, @PurchasedItem, @DatePurchased, @ItemCost)", spParams);
        }
        catch (Exception)
        {
            return ("An error occurred");
        }
    }
}
