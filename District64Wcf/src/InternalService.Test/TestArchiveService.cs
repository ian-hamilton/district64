using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using NUnit.Framework;
using log4net.Config;
using District64.District64Wcf.InternalService;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.Domain.Criterions;
using District64.District64Wcf.Domain.Criterions.Impl;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.InternalService.Test
{   
    [TestFixture]
    public class TestArchiveService
    {
        MockRepository _mockRepository;
        IArchiveRepository _archiveRepos;

        [SetUp]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();

            ArchiveItem item = new ArchiveItem() { ArchiveReposId = 100, ArchiveReposLongDesc = "LONGDESC", ArchiveReposShortDesc = "SHORTDESC", DistrictNumber = 64 };
            List<ArchiveItem> returnList = new List<ArchiveItem>();
            returnList.Add(item);
            ArchiveCriterion criteria = new ArchiveCriterion()
            {
                BeginYear = null,
                EndYear = null,
                IsFeatured = true,
                Type = null,
                DistrictNumber = 64
            };

            _mockRepository = new MockRepository();
            _archiveRepos = _mockRepository.StrictMock<IArchiveRepository>();
            Expect.Call(_archiveRepos.Read(100)).Return(item);
            Expect.Call(_archiveRepos.Find(criteria)).IgnoreArguments().Return(returnList);
            _mockRepository.ReplayAll();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository = null;
        }

        [Test]
        public void TestAddArchiveFile()
        {
            IArchiveRepository archiveRepos = _mockRepository.DynamicMock<IArchiveRepository>();
            ArchiveItem item = new ArchiveItem();

            ArchiveService service = new ArchiveService(archiveRepos);
            service.AddArchiveFile(item);
        }
        
        [Test]
        public void TestGetArchiveItem()
        {
            ArchiveService service = new ArchiveService(_archiveRepos);
            ArchiveItem a = service.GetArchiveItem(100);

            Assert.AreEqual(a.ArchiveReposId, 100);
            Assert.AreEqual(a.ArchiveReposLongDesc, "LONGDESC");
            Assert.AreEqual(a.ArchiveReposShortDesc, "SHORTDESC");

        }

        [Test]
        public void TestSearchArchiveItems()
        {
            ArchiveService service = new ArchiveService(_archiveRepos);
            List<ArchiveItem> list = service.SearchArchiveItems(null, null, null, 64, null, true);

            ArchiveItem a = list[0];
            Assert.AreEqual(a.ArchiveReposId, 100);
            Assert.AreEqual(a.ArchiveReposLongDesc, "LONGDESC");
            Assert.AreEqual(a.ArchiveReposShortDesc, "SHORTDESC");
        }
    }
}
