using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace District64.District64Mvc.Models.Archive.Domain
{
    public class ArchiveTypeVO : IComparable
    {
        public string ArchiveTypeName { get; set; }
        public int ArchiveTypeValue { get; set; }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            ArchiveTypeVO other = (ArchiveTypeVO)obj;
            return String.Compare(this.ArchiveTypeName, other.ArchiveTypeName);
        }

        #endregion
    }
}