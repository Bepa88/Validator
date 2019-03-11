﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MaxLengthAttribute : System.Attribute
    {
        public int Length { get; set; }

        public MaxLengthAttribute(int length)
        {
            Length = length;
        }
    }
}
