using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Tests
{
    class ClassWithMinValueProperty
    {
        [MinValueAttribute(0)]
        public int MinValueProperty { get; set; }
    }
}
