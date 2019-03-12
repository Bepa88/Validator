using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Tests
{
    class ClassWithRequiredAndMinLengnthProperty
    {
        [MinLength(5)]
        [MaxLength(10)]
        public string Property { get; set; }
    }
}
