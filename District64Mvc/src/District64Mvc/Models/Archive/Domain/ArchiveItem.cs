using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace District64.District64Mvc.Models.Archive.Domain
{
    public class ArchiveItem
    {
        public long ArchiveReposIdField { get; set; }

        public string ArchiveReposLongDescField { get; set; }

        public string ArchiveReposShortDescField { get; set; }

        public int ArchiveTypeId { get; set; }

        public string ArchiveTypeName { get; set; }

        public int? DistrictNumberField { get; set; }

        public bool IsFeaturedItemField { get; set; }

        public int? YearField { get; set; }

        public byte[] FileByteArray { get; set; }

        public string FileName { get; set; }
    }
}