using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Tests
{
    class ClassWithMaxValueProperty
    {
        [MaxValueAttribute(100)]
        public int MaxValueProperty { get; set; }
    }
}
