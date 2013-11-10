using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Enums;

namespace District64.District64Wcf.ConsoleClient.DirectoryInfo
{
    public class ArchiveDirectoryInfo
    {
        public string rootPath { get; set; }
        public string ShortDesc { get; set; }
        public int? Year { get; set; }
        public int? District { get; set; }
        public IDictionary<string, Domain.Enums.ArchiveTypeEnumArchiveType> filePathsDictionary { get; set; }
    }
}
