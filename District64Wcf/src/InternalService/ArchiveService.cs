using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.Domain.Criterions;
using District64.District64Wcf.Domain.Criterions.Impl;
using District64.District64Wcf.Domain.Enums;

namespace District64.District64Wcf.InternalService
{
    /// <summary>
    /// Service used for all Archive 
    /// activities and rules
    /// </summary>
    public class ArchiveService
    {
        IArchiveRepository _archiveRepository;

        /// <summary>
        /// Parameterized Constructor:
        /// </summary>
        /// <param name="archiveRepository">Repository for Archive Domains</param>
        public ArchiveService(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
        }

        /// <summary>
        /// Adds archive item to repository
        /// </summary>
        /// <param name="archiveItem">Archive Agregete domain for saving</param>
        public void AddArchiveFile(ArchiveItem archiveItem)
        {
            _archiveRepository.SaveOrUpdate(archiveItem);
        }

        /// <summary>
        /// Searches the Archive Repository 
        /// for Lazy List of Archive Items, using a set of basic
        /// searching filters
        /// </summary>
        /// <param name="beginYear">Year Search</param>
        /// <param name="endYear">End Year Search</param>
        /// <param name="type">The Archive Type</param>
        /// <param name="districtNumber">Distict</param>
        /// <param name="description">Description Search for short and long</param>
        /// <param name="isFeatured">if it's a featured item on the can be used for the main page</param>
        /// <returns></returns>
        public List<ArchiveItem> SearchArchiveItems(int? beginYear, int? endYear, 
            ArchiveTypeEnum.ArchiveType? type, int? districtNumber, string description, bool isFeatured)
        {
            ArchiveCriterion criterion = new ArchiveCriterion()
            {
                BeginYear = beginYear,
                EndYear = endYear,
                IsFeatured = isFeatured,
                Type = type,
                DistrictNumber = districtNumber,
                Description = description
            };

            return _archiveRepository.Find(criterion);
        }

        public ArchiveItem GetArchiveItem(long id)
        {
            return _archiveRepository.Read(id);
        }
    }
}
