using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Tests
{
    class ClassWithMaxLengthProperty
    {
        [MaxLengthAttribute(5)]
        public string MaxLengthProperty { get; set; }
    }
}
