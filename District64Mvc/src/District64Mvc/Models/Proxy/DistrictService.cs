﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace District64.District64Wcf.Domain.Entities
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArchiveItem", Namespace="http://schemas.datacontract.org/2004/07/District64.District64Wcf.Domain.Entities")]
    public partial class ArchiveItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long ArchiveReposIdField;
        
        private string ArchiveReposLongDescField;
        
        private string ArchiveReposShortDescField;
        
        private District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType ArchiveTypeField;
        
        private System.Nullable<int> DistrictNumberField;
        
        private District64.District64Wcf.Domain.Entities.ArchiveFile FileField;
        
        private string FilePathField;
        
        private bool IsFeaturedItemField;
        
        private bool IsValidStatusField;
        
        private long UserField;
        
        private System.Nullable<int> YearField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ArchiveReposId
        {
            get
            {
                return this.ArchiveReposIdField;
            }
            set
            {
                this.ArchiveReposIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArchiveReposLongDesc
        {
            get
            {
                return this.ArchiveReposLongDescField;
            }
            set
            {
                this.ArchiveReposLongDescField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArchiveReposShortDesc
        {
            get
            {
                return this.ArchiveReposShortDescField;
            }
            set
            {
                this.ArchiveReposShortDescField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType ArchiveType
        {
            get
            {
                return this.ArchiveTypeField;
            }
            set
            {
                this.ArchiveTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> DistrictNumber
        {
            get
            {
                return this.DistrictNumberField;
            }
            set
            {
                this.DistrictNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public District64.District64Wcf.Domain.Entities.ArchiveFile File
        {
            get
            {
                return this.FileField;
            }
            set
            {
                this.FileField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FilePath
        {
            get
            {
                return this.FilePathField;
            }
            set
            {
                this.FilePathField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsFeaturedItem
        {
            get
            {
                return this.IsFeaturedItemField;
            }
            set
            {
                this.IsFeaturedItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsValidStatus
        {
            get
            {
                return this.IsValidStatusField;
            }
            set
            {
                this.IsValidStatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Year
        {
            get
            {
                return this.YearField;
            }
            set
            {
                this.YearField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArchiveFile", Namespace="http://schemas.datacontract.org/2004/07/District64.District64Wcf.Domain.Entities")]
    public partial class ArchiveFile : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private byte[] ByteArrayField;
        
        private long FileIdField;
        
        private string FileNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ByteArray
        {
            get
            {
                return this.ByteArrayField;
            }
            set
            {
                this.ByteArrayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long FileId
        {
            get
            {
                return this.FileIdField;
            }
            set
            {
                this.FileIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName
        {
            get
            {
                return this.FileNameField;
            }
            set
            {
                this.FileNameField = value;
            }
        }
    }
}
namespace District64.District64Wcf.Domain.Enums
{
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArchiveTypeEnum.ArchiveType", Namespace="http://schemas.datacontract.org/2004/07/District64.District64Wcf.Domain.Enums")]
    public enum ArchiveTypeEnumArchiveType : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Schedule = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Letter = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Minutes = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Flyers = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PassItOn = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Conference = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Assembly = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Article = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Concepts = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Misc = 10,
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IDistrictService")]
public interface IDistrictService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistrictService/AddArchiveFile", ReplyAction="http://tempuri.org/IDistrictService/AddArchiveFileResponse")]
    void AddArchiveFile(District64.District64Wcf.Domain.Entities.ArchiveItem archiveItem);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistrictService/SearchArchiveItems", ReplyAction="http://tempuri.org/IDistrictService/SearchArchiveItemsResponse")]
    District64.District64Wcf.Domain.Entities.ArchiveItem[] SearchArchiveItems(System.Nullable<int> beginYear, System.Nullable<int> endYear, System.Nullable<District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType> type, System.Nullable<int> districtNumber, string description, bool isFeatured);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistrictService/GetArchiveItem", ReplyAction="http://tempuri.org/IDistrictService/GetArchiveItemResponse")]
    District64.District64Wcf.Domain.Entities.ArchiveItem GetArchiveItem(long id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistrictService/HasPageOrRouteAccess", ReplyAction="http://tempuri.org/IDistrictService/HasPageOrRouteAccessResponse")]
    bool HasPageOrRouteAccess(long userId, string PageOrRoute);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IDistrictServiceChannel : IDistrictService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class DistrictServiceClient : System.ServiceModel.ClientBase<IDistrictService>, IDistrictService
{
    
    public DistrictServiceClient()
    {
    }
    
    public DistrictServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public DistrictServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DistrictServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DistrictServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void AddArchiveFile(District64.District64Wcf.Domain.Entities.ArchiveItem archiveItem)
    {
        base.Channel.AddArchiveFile(archiveItem);
    }
    
    public District64.District64Wcf.Domain.Entities.ArchiveItem[] SearchArchiveItems(System.Nullable<int> beginYear, System.Nullable<int> endYear, System.Nullable<District64.District64Wcf.Domain.Enums.ArchiveTypeEnumArchiveType> type, System.Nullable<int> districtNumber, string description, bool isFeatured)
    {
        return base.Channel.SearchArchiveItems(beginYear, endYear, type, districtNumber, description, isFeatured);
    }
    
    public District64.District64Wcf.Domain.Entities.ArchiveItem GetArchiveItem(long id)
    {
        return base.Channel.GetArchiveItem(id);
    }
    
    public bool HasPageOrRouteAccess(long userId, string PageOrRoute)
    {
        return base.Channel.HasPageOrRouteAccess(userId, PageOrRoute);
    }
}
