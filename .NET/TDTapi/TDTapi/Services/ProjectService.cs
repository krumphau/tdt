using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDTapi.Models;
using TDTapi.Utils;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace TDTapi.Services
{
    public static class ProjectService
    {
        public static string CreateProject(ProjectModel project, string connstring)
        {
            Dictionary<string, object> spParams = new Dictionary<string, object>();
            spParams.Add("@ProjectIdentifier", project.ProjectIdentifier);
            spParams.Add("@ProjectName", project.ProjectName);
            spParams.Add("@ProjectDescription", project.ProjectDescription);
            spParams.Add("@ApplicationDate", project.ApplicationDate);
            spParams.Add("@DateGrantApproved", project.DateGrantApproved);
            spParams.Add("@DateGrantPaid", project.DateGrantPaid);
            spParams.Add("@TargetCompletionDate", project.TargetCompletionDate);
            spParams.Add("@AmountGrantRequested", project.AmountGrantRequested);
            spParams.Add("@AmountGrantApproved", project.AmountGrantApproved);
            spParams.Add("@AmountGrantRecommended", project.AmountGrantRecommended);
            spParams.Add("@AmountGrantPaid", project.AmountGrantPaid);
            spParams.Add("@TotalProjectCost", project.TotalProjectCost);
            spParams.Add("@StatusCode_Id", project.StatusCode_Id);
            spParams.Add("@StatusCodeDate", project.StatusCodeDate);
            spParams.Add("@Region_Id", project.Region_Id);
            spParams.Add("@District_Id", project.District_Id);
            spParams.Add("@ProjOfficer_Id", project.ProjOfficer_Id);
            return DBAccess.ExecuteSQLScalar(connstring, "CALL usp_InsertProject(@ProjectIdentifier, @ProjectName, @ProjectDescription, @ApplicationDate, @DateGrantApproved, " +
                "@DateGrantPaid, @TargetCompletionDate, @AmountGrantRequested, @AmountGrantApproved, @AmountGrantRecommended, @AmountGrantPaid, @TotalProjectCost, " +
                "@StatusCode_Id, @StatusCodeDate, @Region_Id, @District_Id, @ProjOfficer_Id)", spParams);
        }

        public static List<ProjectModel> GetProjects(string connstring)
        {
            try
            {
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetAllProjects");
                List<ProjectModel> projects = new List<ProjectModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    projects.Add(dr.ToObject<ProjectModel>());
                }

                return projects;
            }
            catch (Exception)
            {
                return new List<ProjectModel>();
            }
        }

        public static ProjectModel GetProject(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_GetProject(@Id)", spParams);
                return ds.Tables[0].Rows[0].ToObject<ProjectModel>();
                
            }
            catch (Exception)
            {
                return default(ProjectModel);
            }
        }

        public static string DeleteProject(int id, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", id);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_DeleteProject(@Id)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

      
        public static string UpdateProject(ProjectModel project, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", project.Id);
                spParams.Add("@ProjectIdentifier", project.ProjectIdentifier);
                spParams.Add("@ProjectName", project.ProjectName);
                spParams.Add("@ProjectDescription", project.ProjectDescription);
                spParams.Add("@ApplicationDate", project.ApplicationDate);
                spParams.Add("@DateGrantApproved", project.DateGrantApproved);
                spParams.Add("@DateGrantPaid", project.DateGrantPaid);
                spParams.Add("@TargetCompletionDate", project.TargetCompletionDate);
                spParams.Add("@AmountGrantRequested", project.AmountGrantRequested);
                spParams.Add("@AmountGrantApproved", project.AmountGrantApproved);
                spParams.Add("@AmountGrantRecommended", project.AmountGrantRecommended);
                spParams.Add("@AmountGrantPaid", project.AmountGrantPaid);
                spParams.Add("@TotalProjectCost", project.TotalProjectCost);
                spParams.Add("@StatusCode_Id", project.StatusCode_Id);
                spParams.Add("@StatusCodeDate", project.StatusCodeDate);
                spParams.Add("@Region_Id", project.Region_Id);
                spParams.Add("@District_Id", project.District_Id);
                spParams.Add("@ProjOfficer_Id", project.ProjOfficer_Id);
                spParams.Add("@LastUpdatedBy", project.LastUpdatedBy);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateProjectDetails(@Id, @ProjectIdentifier, @ProjectName, @ProjectDescription, @ApplicationDate, @DateGrantApproved, " +
                    "@DateGrantPaid, @TargetCompletionDate, @AmountGrantRequested, @AmountGrantApproved, @AmountGrantRecommended, @AmountGrantPaid, @TotalProjectCost, " +
                    "@StatusCode_Id, @StatusCodeDate, @Region_Id, @District_Id, @ProjOfficer_Id, @LastUpdatedBy)", spParams);
            }
            catch (Exception ex)
            {
                return ("An error occurred");
            }
        }

        
        public static string UpdateProjectNotes(ProjectNotesModel notes, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", notes.ProjectId);
                spParams.Add("@StatusDescription", notes.StatusDescription);
                spParams.Add("@ProjOfficerRecommendation", notes.ProjOfficerRecommendation);
                spParams.Add("@Keywords", notes.Keywords);
                spParams.Add("@Summary", notes.Summary);
                spParams.Add("@Problems", notes.Problems);
                spParams.Add("@StrengthsWeaknesses", notes.StrengthsWeaknesses);
                spParams.Add("@FinanceOtherFunders", notes.FinanceOtherFunders);
                spParams.Add("@LocalContribution", notes.LocalContribution);
                spParams.Add("@LastUpdatedBy", notes.LastUpdatedBy);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateProjectNotes(@Id, @StatusDescription, @ProjOfficerRecommendation, @Keywords," +
                    "@Summary, @Problems, @StrengthsWeaknesses," +
                    "@FinanceOtherFunders,@LocalContribution,@LastUpdatedBy)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static string UpdateProjectMetadata(ProjectMetadataModel meta, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Id", meta.ProjectId);
                spParams.Add("@Impact", meta.Impact);
                spParams.Add("@WebsitePicture", meta.WebsitePicture);
                spParams.Add("@Caption", meta.Caption);
                spParams.Add("@Latitude", meta.Latitude);
                spParams.Add("@Longitude", meta.Longitude);
                spParams.Add("@LastUpdatedBy", meta.LastUpdatedBy);
                return DBAccess.ExecuteSQLNonQuery(connstring, "CALL usp_UpdateProjectMetadata(@Id, @Impact, @WebsitePicture, @Caption," +
                    "@Latitude, @Longitude, @LastUpdatedBy)", spParams);
            }
            catch (Exception)
            {
                return ("An error occurred");
            }
        }

        public static List<ProjectModel> SearchProjects(SearchModel search, string connstring)
        {
            try
            {
                Dictionary<string, object> spParams = new Dictionary<string, object>();
                spParams.Add("@Identifier", search.Identifier);
                spParams.Add("@RegionID", search.RegionID);
                spParams.Add("@Name", search.Name);
                spParams.Add("@NGOId", search.NGOId);
                spParams.Add("@Keywords", search.Keywords);
                spParams.Add("@OfficerId", search.OfficerId);
                spParams.Add("@Status", search.Status);
                spParams.Add("@FunderId", search.FunderId);
                spParams.Add("@CategoryId", search.CategoryId);
                spParams.Add("@DistrictId", search.DistrictId);
                spParams.Add("@OtherBodyId", search.OtherBodyId);
                DataSet ds = DBAccess.ExecuteDataSet(connstring, "CALL usp_SearchProjects(@Identifier, @RegionID, @Name, @NGOId, @Keywords, @OfficerId, @Status, @FunderId, @CategoryId, @DistrictId, @OtherBodyId)", spParams);
                List<ProjectModel> projects = new List<ProjectModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    projects.Add(dr.ToObject<ProjectModel>());
                }

                return projects;
            }
            catch (Exception)
            {
                return new List<ProjectModel>();
            }
        }
    }

}

