using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapperTest.Fakes
{
    public class FakeClass
    {
        public Guid Id { get; set; }

        public List<InnerClass> InnerClasses { get; set; } 

        public class InnerClass
        {
            public Guid InnerClassGuid { get; set; }
        }
    }
}
