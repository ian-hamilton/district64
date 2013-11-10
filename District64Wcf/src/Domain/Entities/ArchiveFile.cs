using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace District64.District64Wcf.Domain.Entities
{
    [DataContract]
    public class ArchiveFile
    {
        [DataMember]
        public long FileId { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public byte[] ByteArray { get; set; }

    }
}
