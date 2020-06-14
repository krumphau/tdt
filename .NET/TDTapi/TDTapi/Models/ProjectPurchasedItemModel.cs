using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectPurchasedItemModel
    {
        public int? Id { get; set; }
        [Display(Name = "Project_Id")]
        public int ProjectId { get; set; }
        public string PurchasedItem { get; set; }
        public string DatePurchased { get; set; }
        public decimal ItemCost { get; set; }
    }
}
