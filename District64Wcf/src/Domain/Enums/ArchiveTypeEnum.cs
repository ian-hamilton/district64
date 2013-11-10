using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Exceptions;

namespace District64.District64Wcf.Domain.Enums
{
    /// <summary>
    /// Archive type Enum helper wrappers class
    /// to guide through code and type conversions
    /// </summary>
    public static class ArchiveTypeEnum
    {
        /// <summary>
        /// Type enum with the Type Id as the enum
        /// value
        /// </summary>
        public enum ArchiveType : int
        {
            Schedule = 1,
            Letter = 2,
            Minutes = 3,
            Flyers = 4,
            PassItOn = 5,
            Conference = 6,
            Assembly = 7,
            Article = 8,
            Concepts = 9,
            Misc = 10
        }

        /// <summary>
        /// Converts to actual enum type, throws EnumConvertException 
        /// </summary>
        /// <param name="id">Id used to find conversion enum</param>
        /// <returns>actual Archive enum type</returns>
        public static ArchiveType ConvertFromCode(long id)
        {
            switch (id)
            {
                case 1:
                    return ArchiveType.Schedule;
                case 2:
                    return ArchiveType.Letter;
                case 3:
                    return ArchiveType.Minutes;
                case 4:
                    return ArchiveType.Flyers;
                case 5:
                    return ArchiveType.PassItOn;
                case 6:
                    return ArchiveType.Conference;
                case 7:
                    return ArchiveType.Assembly;
                case 8:
                    return ArchiveType.Article;
                case 9:
                    return ArchiveType.Concepts;
                case 10:
                    return ArchiveType.Misc;
                default:
                    throw new EnumConvertException(String.Format("Archive type code of '{0}' not valid", id));
            }
        }

        /// <summary>
        /// Converts to int, throws EnumConvertException
        /// </summary>
        /// <param name="archiveType">The Archive Type to be converted</param>
        /// <returns>int value of the ArchiveType</returns>
        public static int ConvertFromType(ArchiveType archiveType)
        {
            switch (archiveType)
            {
                case ArchiveType.Misc:
                    return 10;
                case ArchiveType.Concepts:
                    return 9;
                case ArchiveType.Article:
                    return 8;
                case ArchiveType.Assembly:
                    return 7;
                case ArchiveType.Conference:
                    return 6;
                case ArchiveType.PassItOn:
                    return 5;
                case ArchiveType.Flyers:
                    return 4;
                case ArchiveType.Minutes:
                    return 3;
                case ArchiveType.Letter:
                    return 2;
                case ArchiveType.Schedule:
                    return 1;
                default:
                    throw new EnumConvertException(String.Format("Archive Type of '{0}' is not a valid Type", archiveType.ToString()));
            }

        }
    }
}
