using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace District64.District64Mvc.Models
{
    /// <summary>
    /// Constants *Static*
    /// </summary>
    public class District64MvcConstants
    {
        public const string VIEW_DATA_TYPE_LIST = "typelist";
        public const string VIEW_DATA_ARCHIVE_LIST = "archivelist";
        public const string VIEW_DATA_ARCHIVE_ID = "id";

        public const string COOKIE_DESCRIPTION = "Description";
        public const string COOKIE_DISTRICT_NUMBER = "DistrictNumber";
        public const string COOKIE_ARCHIVE_TYPE = "ArchiveType";
        public const string COOKIE_FROM_YEAR = "FromYear";
        public const string COOKIE_TO_YEAR = "ToYear";
        public const string COOKIE_NAME_USER = "SessionRequestor";

        public const string OBJECT_PROP_ARCHIVE_NAME = "ArchiveTypeName";
        public const string OJBECT_PROP_ARCHIVE_VALUE = "ArchiveTypeValue";
    }
}