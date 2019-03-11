using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MaxValueAttribute : System.Attribute
    {
        public int Value { get; set; }

        public MaxValueAttribute(int value)
        {
            Value = value;
        }
    }
}
