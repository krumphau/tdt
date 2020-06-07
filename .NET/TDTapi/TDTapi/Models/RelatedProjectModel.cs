using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class RelatedProjectModel
    {
        public int? Id { get; set; }
        [Display(Name = "Project_Id")]
        public int ProjectId { get; set; }
        public int RelationshipKey { get; set; }
    }
}
