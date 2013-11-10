using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace District64.District64Mvc.Models.Archive.Domain
{
    public class ArchiveItemAdapter
    {
        public static ArchiveItem Adapt(District64.District64Wcf.Domain.Entities.ArchiveItem serviceItem)
        {
            ArchiveItem ret = new ArchiveItem()
            {
                ArchiveReposIdField = serviceItem.ArchiveReposId,
                ArchiveReposLongDescField = serviceItem.ArchiveReposLongDesc,
                ArchiveReposShortDescField = serviceItem.ArchiveReposShortDesc,
                ArchiveTypeId = (int)serviceItem.ArchiveType,
                ArchiveTypeName = serviceItem.ArchiveType.ToString(),
                DistrictNumberField = serviceItem.DistrictNumber,
                IsFeaturedItemField = serviceItem.IsFeaturedItem,
                YearField = serviceItem.Year              
            };

            if (serviceItem.File != null)
            {
                ret.FileName = serviceItem.File.FileName;
                ret.FileByteArray = serviceItem.File.ByteArray;
            }

            return ret;
        }              
    }
}