using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Enums;
using District64.District64Wcf.Domain.Criterions;

namespace District64.District64Wcf.Domain.Criterions.Impl
{
    /// <summary>
    /// Implemented criteria class 
    /// containing filter criterion
    /// for Archive Repository searches
    /// </summary>
    public class ArchiveCriterion : ICriteria 
    {
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public ArchiveTypeEnum.ArchiveType? Type { get; set; }
        public bool IsFeatured { get; set; }
        public int? DistrictNumber { get; set; }
        public string Description { get; set; }

    }
}
