using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectNotesModel
    {
        public int ProjectId { get; set; }
        public string StatusDescription { get; set; }
        public string ProjOfficerRecommendation { get; set; }
        public string Keywords { get; set; }
        public string Summary { get; set; }
        public string Problems { get; set; }
        public string StrengthsWeaknesses { get; set; }
        public string FinanceOtherFunders { get; set; }
        public string LocalContribution { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
