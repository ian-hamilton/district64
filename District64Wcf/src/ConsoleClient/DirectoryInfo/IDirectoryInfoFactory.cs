using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.ConsoleClient.DirectoryInfo
{
    public interface IDirectoryInfoFactory
    {
        ArchiveDirectoryInfo CreateInfo(string rootDirectoryPath);
    }
}
