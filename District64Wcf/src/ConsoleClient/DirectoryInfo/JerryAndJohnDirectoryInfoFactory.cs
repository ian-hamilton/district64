using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using District64.District64Wcf.Domain.Enums;


namespace District64.District64Wcf.ConsoleClient.DirectoryInfo
{
    public class JerryAndJohnDirectoryInfoFactory : IDirectoryInfoFactory
    {
        //public const string ALANO_CLUB = "Alano Club";
        public const string DISTRIC_6 = "District 6";
        public const string DISTRICT_60 = "District 60";
        public const string DISTRICT_62 = "District 62";
        public const string DISTRICT_63 = "District 63";
        public const string DISTRICT_64 = "District 64";
        //public const string FLYERS = "Flyers";
        //public const string COOP = "InterDistrict Co Op";
        //public const string SCHEDULE = "Schedules";
        //public const string WORKSHOP = "Workshops";

        public const int INT_64 = 64;
        public const int INT_63 = 63;
        public const int INT_62 = 62;
        public const int INT_60 = 60;
        public const int INT_6 = 6;

        public const int START_YEAR = 1970;
        public const int END_YEAR = 2011;

        private const string MINUTES = "Minutes";
        private const string SCHEDULES = "Schedules";
        private const string NEWS = "News Article";
        private const string PASS_IT_ON = "Pass It On";
        private const string CONCEPTS = "Concepts";
        private const string NIA = "NIA";
        private const string CONFERENCE = "Conference";
        private const string ASSEMBLY = "Assembly";        
        private const string GSO = "GSO";

        private const string PATTERN = "*.pdf";

        #region IDirectoryInfoFactory Members

        public ArchiveDirectoryInfo CreateInfo(string rootDirectoryPath)
        {
            ArchiveDirectoryInfo info = new ArchiveDirectoryInfo();
            info.rootPath = rootDirectoryPath;
            info.ShortDesc = Path.GetFileNameWithoutExtension(rootDirectoryPath);
            info.Year = ConvertYear(rootDirectoryPath);
            info.District = ConvertDistrict(rootDirectoryPath);

            IDictionary<string, ArchiveTypeEnumArchiveType> dictionary = new Dictionary<string, ArchiveTypeEnumArchiveType>();
            string[] fileSetDirectoryPaths = Directory.GetDirectories(rootDirectoryPath);

            if (fileSetDirectoryPaths.Length == 0)
            {
                foreach (string filePath in Directory.GetFiles(rootDirectoryPath, PATTERN))
                {
                    dictionary.Add(filePath, ArchiveTypeEnumArchiveType.Misc);
                }
            }
            else
            {
                foreach (string fileSetDirectoryPath in fileSetDirectoryPaths)
                {
                    ArchiveTypeEnumArchiveType type = ConvertType(fileSetDirectoryPath);
                    foreach (string filePath in Directory.GetFiles(fileSetDirectoryPath, PATTERN))
                    {
                        dictionary.Add(filePath, type);
                    }

                }
            }

            info.filePathsDictionary = dictionary;
            return info;
        }

        #endregion

        internal ArchiveTypeEnumArchiveType ConvertType(string fileSetDirectoryPath)
        {
            string dir = Path.GetFileNameWithoutExtension(fileSetDirectoryPath);

            if (dir.Contains(MINUTES))
                return ArchiveTypeEnumArchiveType.Minutes;
            else if (dir.Contains(SCHEDULES))
                return ArchiveTypeEnumArchiveType.Schedule;
            else if (dir.Contains(NEWS))
                return ArchiveTypeEnumArchiveType.Article;
            else if (dir.Contains(PASS_IT_ON))
                return ArchiveTypeEnumArchiveType.PassItOn;
            else if (dir.Contains(CONCEPTS))
                return ArchiveTypeEnumArchiveType.Concepts;
            else if (dir.Contains(NIA) && dir.Contains(CONFERENCE))
                return ArchiveTypeEnumArchiveType.Conference;
            else if (dir.Contains(NIA) && dir.Contains(ASSEMBLY))
                return ArchiveTypeEnumArchiveType.Assembly;
            else return ArchiveTypeEnumArchiveType.Misc;
        }

        internal int? ConvertYear(string rootDirectoryPath)
        {
            int? year = null;

            for (int y = START_YEAR; y <= END_YEAR; y++)
            {
                if(rootDirectoryPath.Contains(y.ToString()))
                {
                    year = y;
                    break;
                }
            }

            return year;
        }

        internal int? ConvertDistrict(string rootDirectoryPath)
        {

            string dir = Path.GetFileNameWithoutExtension(rootDirectoryPath);

            if (dir.Contains(DISTRICT_60))
                return INT_60;
            else if (dir.Contains(DISTRICT_62))
                return INT_62;
            else if (dir.Contains(DISTRICT_63))
                return INT_63;
            else if (dir.Contains(DISTRICT_64))
                return INT_64;
            else if (dir.Contains(DISTRIC_6))
                return INT_6;
            else return INT_64;

        }
    }
}
