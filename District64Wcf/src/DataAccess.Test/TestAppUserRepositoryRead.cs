using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Transactions;
using NUnit.Framework;
using log4net.Config;
using District64.District64Wcf.DataAccess.Dao;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.DataAccess.Repository.Impl;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.DataAccess.Test
{
    [TestFixture]
    public class TestAppUserRepositoryRead
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test]
        public void TestRead()
        {
            IAppUserRepository repository = new AppUserRepository(new districtEntities());
            AppUser user = repository.Read(1);

            Assert.AreEqual(user.UserId, 1);
            Assert.AreEqual(user.AccessLevel.AccessLevelDesc, "System User");
            Assert.AreEqual(0, user.AccessLevel.AllowedPages.Count);
        }
    }
}
