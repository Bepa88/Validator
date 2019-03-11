using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Tests
{
    class ClassWithMinLengthProperty
    {
        [MinLengthAttribute(1)]
        public string MinLengthProperty { get; set; }
    }
}
