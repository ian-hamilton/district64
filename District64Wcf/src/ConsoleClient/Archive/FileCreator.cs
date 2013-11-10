using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.ConsoleClient.Archive
{
    public static class FileCreator
    {
        public static ArchiveFile CreateArchiveFile(string path)
        {
            ArchiveFile archiveFile = new ArchiveFile();

            archiveFile.FileName = Path.GetFileName(path);
            archiveFile.ByteArray = File.ReadAllBytes(path);

            return archiveFile;
        }
    }
}
