using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.Domain.Criterions.Impl;

namespace District64.District64Wcf.DataAccess.Repository
{
    /// <summary>
    /// Interface for ArchiveRepository
    /// </summary>
    public interface IArchiveRepository : IRespository<ArchiveItem, long>
    {
        List<ArchiveItem> Find(ArchiveCriterion criteria);
    }
}
