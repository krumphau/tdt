using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectCategoryModel
    {
        public int? Id { get; set; }
        [Display(Name ="Project_Id")]
        public int ProjectId { get; set; }
        [Display(Name = "Category_Id")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
