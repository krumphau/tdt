using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectIdentifier { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? DateGrantApproved { get; set; }
        public DateTime? DateGrantPaid { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int? AmountGrantRequested { get; set; }
        public int? AmountGrantApproved { get; set; }
        public int? AmountGrantRecommended { get; set; }
        public int? AmountGrantPaid { get; set; }
        public int? TotalProjectCost { get; set; }
        public int? StatusCode_Id { get; set; }
        public DateTime? StatusCodeDate { get; set; }
        public int? Region_Id { get; set; }
        public int? District_Id { get; set; }
        public int? ProjOfficer_Id { get; set; }
        public string LastUpdatedBy { get; set; }
        public string StatusDescription { get; set; }
        public string ProjOfficerRecommendation { get; set; }
        public string Keywords { get; set; }
        public string Summary { get; set; }
        public string Problems { get; set; }
        public string StrengthsWeaknesses { get; set; }
        public string FinanceOtherFunders { get; set; }
        public string LocalContribution { get; set; }
        public string ImpactOfProject { get; set; }
        //public string WebSitePicture { get; set; }
        public string WebSitePictureDescription { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ProjectOfficerName { get; set; }
        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public string StatusCode { get; set; }
    }
}
