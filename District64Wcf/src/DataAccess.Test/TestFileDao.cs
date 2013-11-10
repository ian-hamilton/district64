using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;
using log4net.Config;
using Rhino.Mocks;
using District64.District64Wcf.Domain.Entities;
using District64.District64Wcf.DataAccess.Dao;

namespace District64.District64Wcf.DataAccess.Test
{
    [TestFixture]
    public class TestFileDao
    {
        [Test]
        public void TestFileRead()
        {
            byte[] bytes = new byte[1];
            MockRepository mockRepository = new MockRepository();
            Stream mockStream = mockRepository.StrictMock<FileStream>();
            Expect.Call(mockStream.Length).Return(0);
            Expect.Call(mockStream.Length).Return(1);
            Expect.Call(mockStream.Read(bytes, 0, 1)).Return(1);
            mockStream.Replay();

            ArchiveIoFileDao fileDao = new ArchiveIoFileDao();
            ArchiveFile file = fileDao.ReadFile((FileStream)mockStream, "@/stream/test/testfile.zip");
        }
    }
}
