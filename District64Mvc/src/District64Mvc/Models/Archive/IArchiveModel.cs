using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Mvc.Models.Archive.Domain;

namespace District64.District64Mvc.Models.Archive
{
    public interface IArchiveModel
    {
       List<ArchiveTypeVO> GetArchiveTypeVOList();

       List<ArchiveItem> GetArchiveItemList(ArchiveSearch search);

       ArchiveItem GetArchiveItemFile(long archiveReposId);
    }
}
