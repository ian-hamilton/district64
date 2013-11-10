using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using NUnit.Framework;
using log4net.Config;
using District64.District64Wcf.InternalService;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.Domain.Entities;


namespace District64.District64Wcf.InternalService.Test
{
    [TestFixture]
    public class TestAppUserService
    {
        MockRepository _mockRepository;
        IAppUserRepository _appUserRepository;

        [TestFixtureSetUp]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();

            AppUser user = new AppUser()
            {
                AccessLevel = new AppUserAccessLevel()
                {
                    AccessLevelDesc = "MockDesc",
                    AccessLevelId = 1,
                    AllowedPages = new List<AppUserAccessLevelPageAccess>()
                },
                FirstName = "MockFirstName",
                LastName = "MockLastName",
                IsValid = true,
                UserId = 1
            };

            user.AccessLevel.AllowedPages.Add(new AppUserAccessLevelPageAccess()
            {
                Page = "MockPage.aspx",
                PageAccessId = 1
            });

            user.AccessLevel.AllowedPages.Add(new AppUserAccessLevelPageAccess()
            {
                Page = "MockController/MockAction",
                PageAccessId = 1
            });

            _mockRepository = new MockRepository();
            _appUserRepository = _mockRepository.StrictMock<IAppUserRepository>();
            Expect.Call(_appUserRepository.Read(100)).Return(user);
            Expect.Call(_appUserRepository.Read(99)).Return(user);
            Expect.Call(_appUserRepository.Read(98)).Return(user);
            Expect.Call(_appUserRepository.Read(1)).Return(null);
            _mockRepository.ReplayAll();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _mockRepository = null;
        }

        [Test]
        public void TestHasAccessServiceCallFalse()
        {
            AppUserService service = new AppUserService(_appUserRepository);

            bool test = service.HasPageOrRouteLevelAccess(100, "dummy.aspx");
            Assert.IsFalse(test);

            test = service.HasPageOrRouteLevelAccess(1, "MockController/MockAction");
            Assert.IsFalse(test);
        }

        [Test]
        public void TestHasAccessServiceCallTrue()
        {
            AppUserService service = new AppUserService(_appUserRepository);

            bool test = service.HasPageOrRouteLevelAccess(99, "MockController/MockAction");
            Assert.IsTrue(test);

            test = service.HasPageOrRouteLevelAccess(98, "MockPage.aspx");
            Assert.IsTrue(test);
        }
    }
}
