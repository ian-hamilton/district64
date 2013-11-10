using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.DataAccess.Dao
{
    public interface IFileDao
    {
        ArchiveFile ReadFile(Stream fileStream, string path);
    }
}
