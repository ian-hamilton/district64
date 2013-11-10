using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using District64.District64Mvc.Models;

namespace District64.District64Mvc.Models.Archive.Domain
{
    public class ArchiveSearch
    {
        [StringLength(100)]
        public string Description { get; set; }

        [Range(1900, 3000, ErrorMessage = "Field needs to be a valid four digit year (YYYY)")]
        public String FromYear { get; set; }

        [Range(1900, 3000, ErrorMessage="Field needs to be a valid four digit year (YYYY)")]
        public String ToYear { get; set; }

        [Range(1, 999, ErrorMessage="Field needs to be a one-to-three digit District Number")]
        public int? District { get; set; }
        
        public int? ArchiveType { get; set; }
    }
}