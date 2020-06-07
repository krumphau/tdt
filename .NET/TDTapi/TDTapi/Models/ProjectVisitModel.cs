using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectVisitModel
    {
        public int? Id { get; set; }
        [Display(Name = "Project_Id")]
        public int ProjectId { get; set; }
        [Display(Name = "VisitDateStart")]
        public DateTime VisitStart { get; set; }
        [Display(Name = "VisitDateEnd")]
        public DateTime VisitEnd { get; set; }
        public string Visitor { get; set; }
    }
}
