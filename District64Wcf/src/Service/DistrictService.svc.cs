using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.Domain.Enums;
using District64.District64Wcf.Domain.Criterions.Impl;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.DataAccess.Repository.Impl;
using District64.District64Wcf.DataAccess.Dao;
using District64.District64Wcf.InternalService;
using log4net;

namespace District64.District64Wcf.Service
{
    public class DistrictService : IDistrictService
    {       
        #region IService Members

        public void AddArchiveFile(ArchiveItem archiveItem)
        {
            ArchiveService internalService = new ArchiveService(new ArchiveRepository(new districtEntities(), new ArchiveIoFileDao()));
            Handler<int?>.WithTryCatch(() => internalService.AddArchiveFile(archiveItem));
        }

        public List<ArchiveItem> SearchArchiveItems(int? beginYear, int? endYear,
            ArchiveTypeEnum.ArchiveType? type, int? districtNumber, string description, bool isFeatured)
        {
            ArchiveService internalService = new ArchiveService(new ArchiveRepository(new districtEntities(), new ArchiveIoFileDao()));
            return Handler<List<ArchiveItem>>.WithTryCatch(() => 
                internalService.SearchArchiveItems(beginYear, endYear, type, districtNumber, description, isFeatured));
        }

        public ArchiveItem GetArchiveItem(long id)
        {
            ArchiveService internalService = new ArchiveService(new ArchiveRepository(new districtEntities(), new ArchiveIoFileDao()));
            return Handler<ArchiveItem>.WithTryCatch(() =>
                internalService.GetArchiveItem(id));
        }

        public bool HasPageOrRouteAccess(long userId, string PageOrRoute)
        {
            AppUserService internalService = new AppUserService(new AppUserRepository(new districtEntities()));
            return Handler<bool>.WithTryCatch(() => 
                internalService.HasPageOrRouteLevelAccess(userId, PageOrRoute));
        }

        #endregion
    }
}
