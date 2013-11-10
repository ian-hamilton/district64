using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.ConsoleClient.DirectoryInfo;

namespace District64.District64Wcf.ConsoleClient.Archive
{
    public class ArchiveItemFactory
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ArchiveItemFactory));

        private static volatile ArchiveItemFactory _instance;

        private ArchiveItemFactory() { }

        public static ArchiveItemFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ArchiveItemFactory();
                }
                return _instance;
            }
        }

        public List<ArchiveItem> CreateArchiveItems(List<ArchiveDirectoryInfo> DirectoryInfoList, bool isLoadingBlob)
        {
            List<ArchiveItem> returnList = new List<ArchiveItem>();

            foreach (ArchiveDirectoryInfo info in DirectoryInfoList)
            {
                foreach (string filePath in info.filePathsDictionary.Keys)
                {
                    _log.Debug(String.Format("Creating Item for path: {0}", filePath));

                    ArchiveItem item = new ArchiveItem()
                    {
                        ArchiveReposShortDesc = info.ShortDesc.Trim(),
                        IsFeaturedItem = false,
                        IsValidStatus = true,
                        User = 1,
                        Year = info.Year,
                        DistrictNumber = info.District,
                        ArchiveType = info.filePathsDictionary[filePath]
                    };

                    if(isLoadingBlob)
                        item.File = FileCreator.CreateArchiveFile(filePath.Trim());
                    else
                        item.FilePath = FilePathAdapter.adapt(filePath);

                    returnList.Add(item);
                }
            }

            return returnList;
        }

    }
}
