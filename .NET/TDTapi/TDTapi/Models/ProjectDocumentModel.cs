using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDTapi.Models
{
    public class ProjectDocumentModel
    {
        public int? Id { get; set; }
        public int ProjectId { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
    }
}
