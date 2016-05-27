using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutofacTest.Fakes;
using NUnit.Framework;

namespace AutofacTest
{
    [TestFixture]
    public class AutofacTest
    {
        /// <summary>
        /// 测试实例化导出
        /// </summary>
        [Test]
        public void RegisterType_InstancePerDependency_Test()
        {
            var builder = new ContainerBuilder();

            //默认模式InstancePerDependency
            builder.RegisterType<FakeClass>().As<IFakeClass>().InstancePerDependency();

            var container = builder.Build();

            var c1 = container.Resolve<IFakeClass>();
            var c2 = container.Resolve<IFakeClass>();

            Assert.AreNotSame(c1, c2);
        }

        /// <summary>
        /// 测试单例导出
        /// </summary>
        [Test]
        public void RegisterType_SingleInstance_Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FakeClass>().As<IFakeClass>().SingleInstance();

            var container = builder.Build();

            var c1 = container.Resolve<IFakeClass>();
            var c2 = container.Resolve<IFakeClass>();

            Assert.AreSame(c1, c2);
        }
    }
}
