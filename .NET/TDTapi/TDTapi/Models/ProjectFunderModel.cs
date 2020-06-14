using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectFunderModel
    {
        public int? Id { get; set; }
        [Display(Name = "Project_Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Funder_Id")]
        public int FunderId { get; set; }
        public decimal AmountFunded { get; set; }
        public string Name { get; set; }
    }
}
