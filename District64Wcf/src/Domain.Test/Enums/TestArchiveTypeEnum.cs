using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace District64.District64Wcf.Domain.Enums
{
    [TestFixture]
    public class TestArchiveTypeEnum
    {
        [Test]
        public void TestConverts()
        {
            ArchiveTypeEnum.ArchiveType type;
            int i;

            type = ArchiveTypeEnum.ConvertFromCode(1);
            Assert.AreEqual(type, ArchiveTypeEnum.ArchiveType.Schedule);

            type = ArchiveTypeEnum.ConvertFromCode(2);
            Assert.AreEqual(type, ArchiveTypeEnum.ArchiveType.Letter);

            i = ArchiveTypeEnum.ConvertFromType(ArchiveTypeEnum.ArchiveType.Schedule);
            Assert.AreEqual(i, 1);

            i = ArchiveTypeEnum.ConvertFromType(ArchiveTypeEnum.ArchiveType.Misc);
            Assert.AreEqual(i, 10);
        }

        [Test]
        [ExpectedException(typeof(District64.District64Wcf.Domain.Exceptions.EnumConvertException))]
        public void TestCodeConversionException()
        {
            ArchiveTypeEnum.ConvertFromCode(100);
        }
    }
}
