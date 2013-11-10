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
using District64.District64Wcf.Domain.Criterions.Impl;
using District64.District64Wcf.Domain.Enums;

namespace District64.District64Wcf.DataAccess.Test
{
    [TestFixture]
    public class TestArchiveRepositoryCRUD
    {
        private ObjectContext _context;
        private TransactionScope _transaction;
        private System.Text.UTF8Encoding _encoding;
        private IArchiveRepository _repository;
        private long _id;
        private long _fileId;

        [TestFixtureSetUp]
        public void Setup()
        {
            log4net.Config.XmlConfigurator.Configure();

            _transaction = new TransactionScope();
            _context = new districtEntities();
            _repository = new ArchiveRepository(_context, null);
            _encoding =new System.Text.UTF8Encoding();

            byte[] byteArray = _encoding.GetBytes("TESTBYTE");

            ArchiveItem archiveItem = new ArchiveItem()
            {
                ArchiveReposLongDesc = "LONG DESC",
                ArchiveReposShortDesc = "SHORT DESC",
                ArchiveType = Domain.Enums.ArchiveTypeEnum.ArchiveType.Misc,
                IsFeaturedItem = true,
                IsValidStatus = true,
                Year = 1992,
                User = 1,
                DistrictNumber = 64,
                File = new ArchiveFile()
                {
                    ByteArray = byteArray,
                    FileName = "TEST"
                }
            };

            _id = _repository.SaveOrUpdate(archiveItem);

            archiveItem = new ArchiveItem()
            {
                ArchiveReposLongDesc = "LONG DESC",
                ArchiveReposShortDesc = "SHORT DESC",
                ArchiveType = Domain.Enums.ArchiveTypeEnum.ArchiveType.Misc,
                IsFeaturedItem = true,
                IsValidStatus = true,
                Year = 2011,
                User = 1,
                DistrictNumber = 64,
                FilePath = "dummyPath"
            };

            _fileId = _repository.SaveOrUpdate(archiveItem);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _context.Dispose();
            _transaction.Dispose();
        }


        [Test]
        public void TestSimpleUpdate()
        {
            byte[] byteArray = _encoding.GetBytes("TESTBYTE");

            ArchiveItem archiveItem = new ArchiveItem()
            {
                ArchiveReposId = _id,
                ArchiveReposLongDesc = "LONG DESC2",
                ArchiveReposShortDesc = "SHORT DESC",
                ArchiveType = Domain.Enums.ArchiveTypeEnum.ArchiveType.Misc,
                IsFeaturedItem = true,
                IsValidStatus = true,
                Year = 1992,
                User = 1,
                DistrictNumber = 64,
                File = new ArchiveFile()
                {
                    ByteArray = byteArray,
                    FileName = "TEST2"
                }
            };

            _id = _repository.SaveOrUpdate(archiveItem);
        }

        [Test]
        public void TestSimpleRead()
        {
            
            ArchiveItem item = _repository.Read(_id);

            Assert.AreEqual(item.ArchiveReposId, _id);
            Assert.AreEqual(item.ArchiveReposLongDesc, "LONG DESC");
            Assert.AreEqual(item.ArchiveReposShortDesc, "SHORT DESC");
            Assert.AreEqual(item.ArchiveType.ToString(), "Misc");
            Assert.IsTrue(item.IsFeaturedItem);
            Assert.IsTrue(item.IsValidStatus);
            Assert.AreEqual(item.Year, 1992);
            Assert.AreEqual(item.DistrictNumber, 64);

            Assert.IsNotNull(item.File, "File is Null");
        }

        [Test]
        public void TestFind()
        {
            ArchiveCriterion criteria = new ArchiveCriterion()
            {
                BeginYear = 1992,
                EndYear = 1992,
                IsFeatured = true,
                DistrictNumber = 64,
                Type = ArchiveTypeEnum.ArchiveType.Misc,
                Description = "SHORT" 
            };

            List<ArchiveItem> list = _repository.Find(criteria);
            Assert.Greater(list.Count, 0);

        }

        [Test]
        public void TestFileRead()
        {
           ArchiveRepository archiveRepository = new ArchiveRepository(_context, new MockFileDao());
           archiveRepository.Stream = new MockStream();
           ArchiveItem item = archiveRepository.Read(_fileId);
           Assert.AreEqual(-100, item.File.FileId);

        }

        private class MockFileDao : IFileDao
        {

            #region IFileDao Members

            public ArchiveFile ReadFile(System.IO.Stream fileStream, string path)
            {
                return new ArchiveFile() { FileId = -100 };
            }

            #endregion
        }

        private class MockStream : System.IO.Stream
        {
            public override bool CanRead
            {
                get { throw new NotImplementedException(); }
            }

            public override bool CanSeek
            {
                get { throw new NotImplementedException(); }
            }

            public override bool CanWrite
            {
                get { throw new NotImplementedException(); }
            }

            public override void Flush()
            {
                throw new NotImplementedException();
            }

            public override long Length
            {
                get { throw new NotImplementedException(); }
            }

            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            public override long Seek(long offset, System.IO.SeekOrigin origin)
            {
                throw new NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }
        }
    }
}
