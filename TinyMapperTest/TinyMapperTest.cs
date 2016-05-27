using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;
using NUnit.Framework;
using TinyMapperTest.Fakes;

namespace TinyMapperTest
{
    [TestFixture]
    public class TinyMapperTest
    {
        /// <summary>
        /// 复制生成一个新对象测试
        /// </summary>
        [Test]
        public void MapperToOtherType()
        {
            var source = new FakeClass();

            source.Id = Guid.NewGuid();
            source.InnerClasses = new List<FakeClass.InnerClass>();
            for (int i = 0; i < 5; i++)
            {
                source.InnerClasses.Add(new FakeClass.InnerClass {InnerClassGuid = Guid.NewGuid()});
            }

            var target = TinyMapper.Map<FakeClassDto>(source);

            Assert.AreNotSame(source, target);
            Assert.AreEqual(source.Id, target.Id);

            Assert.AreEqual(source.InnerClasses.Count, target.InnerClasses.Count);

            for (int i = 0; i < source.InnerClasses.Count; i++)
            {
                Assert.AreEqual(source.InnerClasses[i].InnerClassGuid, target.InnerClasses[i].InnerClassGuid);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MapperToExistsObject()
        {
            var source = new FakeClass();

            source.Id = Guid.NewGuid();
            source.InnerClasses = new List<FakeClass.InnerClass>();
            for (int i = 0; i < 5; i++)
            {
                source.InnerClasses.Add(new FakeClass.InnerClass { InnerClassGuid = Guid.NewGuid() });
            }

            var target = new FakeClassDto();

            target.Id = Guid.NewGuid();
            target.InnerClasses = new List<FakeClassDto.InnerClass>();
            for (int i = 0; i < 5; i++)
            {
                target.InnerClasses.Add(new FakeClassDto.InnerClass { InnerClassGuid = Guid.NewGuid() });
            }

            TinyMapper.Map(source, target);

            Assert.AreNotSame(source, target);
            Assert.AreEqual(source.Id, target.Id);

            Assert.AreEqual(source.InnerClasses.Count, target.InnerClasses.Count);

            for (int i = 0; i < source.InnerClasses.Count; i++)
            {
                Assert.AreEqual(source.InnerClasses[i].InnerClassGuid, target.InnerClasses[i].InnerClassGuid);
            }
        }
    }
}
