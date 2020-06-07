using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectNGOModel
    {
        public int? Id { get; set; }
        [Display(Name = "Project_Id")]
        public int ProjectId { get; set; }
        [Display(Name = "NGO_Id")]
        public int NGOId { get; set; }
    }
}
