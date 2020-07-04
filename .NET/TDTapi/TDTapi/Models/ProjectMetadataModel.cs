using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectMetadataModel
    {
        public int ProjectId { get; set; }
        public string Impact { get; set; }
        public string WebsitePicture { get; set; }
        public string Caption { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
