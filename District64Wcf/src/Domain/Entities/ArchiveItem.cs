using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace District64.District64Wcf.Domain.Entities
{
    [DataContract]
    public class ArchiveItem 
    {
        [DataMember]
        public long ArchiveReposId { get; set; }

        [DataMember]
        public string ArchiveReposShortDesc { get; set; }

        [DataMember]
        public string ArchiveReposLongDesc { get; set; }

        [DataMember]
        public int? Year { get; set; }

        [DataMember]
        public bool IsFeaturedItem { get; set; }

        [DataMember]
        public bool IsValidStatus { get; set; }

        [DataMember]
        public long User { get; set; }

        [DataMember]
        public Enums.ArchiveTypeEnum.ArchiveType ArchiveType { get; set; }

        [DataMember]
        public ArchiveFile File { get; set; }

        [DataMember]
        public int? DistrictNumber { get; set; }

        [DataMember]
        public string FilePath { get; set; }

    }
}
