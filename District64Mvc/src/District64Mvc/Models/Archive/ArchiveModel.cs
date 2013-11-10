using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using District64.District64Mvc.Models.Archive.Domain;
using District64.District64Wcf.Domain.Enums;

namespace District64.District64Mvc.Models.Archive
{
    /// <summary>
    /// Model for Archive, interacts with WcfProxy
    /// and internal domain POCO
    /// </summary>
    public class ArchiveModel : IArchiveModel
    {

        IDistrictService _service;

        /// <summary>
        /// Parameterized Constructor, injecting the WCF service
        /// mainly used for UNIT testing
        /// </summary>
        /// <param name="service">WCF Service</param>
        public ArchiveModel(IDistrictService service)
        {
            _service = service;
        }

        /// <summary>
        /// Default Constructor, calls and injects DistrictServiceClient
        /// </summary>
        public ArchiveModel() : this(new DistrictServiceClient()) { }

        #region IArchiveModel Members

        /// <summary>
        /// Queries the proxy enum for Archive Type List
        /// </summary>
        /// <returns>List of Archive Types</returns>
        public List<ArchiveTypeVO> GetArchiveTypeVOList()
        {
            List<ArchiveTypeVO> ret = new List<ArchiveTypeVO>();

            string[] nameArray = Enum.GetNames(typeof(District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType));
            Array valueArray = Enum.GetValues(typeof(District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType));

            for (int i = 0; i < nameArray.Length; i++)
            {
                ArchiveTypeVO vo = new ArchiveTypeVO()
                {
                    ArchiveTypeName = nameArray[i],
                    ArchiveTypeValue = (Int32)valueArray.GetValue(i)
                };

                ret.Add(vo);
            }

            ret.Sort();
            ret.Insert(0, new ArchiveTypeVO() { ArchiveTypeName = String.Empty, ArchiveTypeValue = -1 });
            return ret;
        }

        /// <summary>
        /// Calls WCF for list of Archive Items for provided
        /// search filter
        /// </summary>
        /// <param name="search">Archive Search Filters</param>
        /// <returns>List of filtered Archive Items</returns>
        public List<ArchiveItem> GetArchiveItemList(ArchiveSearch search)
        {
            int? fromYear = search.FromYear != null && search.FromYear.Length > 0 ? Int32.Parse(search.FromYear) : (int?)null;
            int? toYear = search.ToYear != null && search.ToYear.Length > 0 ? Int32.Parse(search.ToYear) : (int?)null;

            List<District64Wcf.Domain.Entities.ArchiveItem> list =
                new List<District64Wcf.Domain.Entities.ArchiveItem>(_service.SearchArchiveItems(
                    fromYear,
                    toYear,
                    GetType(search.ArchiveType),
                    search.District,
                    search.Description, false));

            List<ArchiveItem> ret = new List<ArchiveItem>();

            foreach (District64Wcf.Domain.Entities.ArchiveItem serviceItem in list)
            {
                ret.Add(ArchiveItemAdapter.Adapt(serviceItem));
            }

            return ret;
        }

        /// <summary>
        /// Gets the archive item including file properties
        /// for provided archive id
        /// </summary>
        /// <param name="archiveReposId">Archive Id</param>
        /// <returns>Archive Item, including File Properties</returns>
        public ArchiveItem GetArchiveItemFile(long archiveReposId)
        {
            return ArchiveItemAdapter.Adapt(_service.GetArchiveItem(archiveReposId));
        }

        #endregion

        private ArchiveTypeEnumArchiveType? GetType(int? id)
        {
            if (!id.HasValue || id < 0)
                return null;

            switch (id)
            {
                case 1:
                    return ArchiveTypeEnumArchiveType.Schedule;
                case 2:
                    return ArchiveTypeEnumArchiveType.Letter;
                case 3:
                    return ArchiveTypeEnumArchiveType.Minutes;
                case 4:
                    return ArchiveTypeEnumArchiveType.Flyers;
                case 5:
                    return ArchiveTypeEnumArchiveType.PassItOn;
                case 6:
                    return ArchiveTypeEnumArchiveType.Conference;
                case 7:
                    return ArchiveTypeEnumArchiveType.Assembly;
                case 8:
                    return ArchiveTypeEnumArchiveType.Article;
                case 9:
                    return ArchiveTypeEnumArchiveType.Concepts;
                case 10:
                    return ArchiveTypeEnumArchiveType.Misc;
                default:
                    throw new Exception(String.Format("Archive type code of '{0}' not valid", id));
            }

        }

    }
}