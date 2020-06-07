using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class SearchModel
    {
        public string Identifier { get; set; }
        public int RegionID { get; set; }
        public string Keywords { get; set; }
        public string Name { get; set; }
        public int NGOId { get; set; }
        public int OfficerId { get; set; }
        public int Status { get; set; }
        public int FunderId { get; set; }
        public int CategoryId { get; set; }
        public int DistrictId { get; set; }
        public int OtherBodyId { get; set; }
    }
}
