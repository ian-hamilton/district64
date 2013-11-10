using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.DataAccess.Dao
{
    public class ArchiveIoFileDao : IFileDao
    {
        public ArchiveFile ReadFile(Stream fileStream, string path)
        {
            ArchiveFile archiveFile = new ArchiveFile()
            {
                FileName = Path.GetFileName(path),
                FileId = 0
            };

            // Read the source file into a byte array.
            archiveFile.ByteArray = new byte[fileStream.Length];
            int numBytesToRead = (int)fileStream.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fileStream.Read(archiveFile.ByteArray, numBytesRead, numBytesToRead);

                // Break when the end of the file is reached.
                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }


            return archiveFile;
        }
    }
}
