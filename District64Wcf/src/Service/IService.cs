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

namespace District64.District64Wcf.Service
{    
    [ServiceContract]
    public interface IDistrictService
    {
        [OperationContract]
        void AddArchiveFile(ArchiveItem archiveItem);

        [OperationContract]
        List<ArchiveItem> SearchArchiveItems(int? beginYear, int? endYear,
            ArchiveTypeEnum.ArchiveType? type, int? districtNumber, string description, bool isFeatured);

        [OperationContract]
        ArchiveItem GetArchiveItem(long id);

        [OperationContract]
        Boolean HasPageOrRouteAccess(long userId, string PageOrRoute);
    }
    
}
