using System;
using System.Collections.Generic;
using System.Text;
using Validator;

namespace Validator.Tests
{
    public class Person
    {
        [RequiredAttribute]
        public int Id { get; set; }

        [MinLengthAttribute(0)]
        [MaxLengthAttribute(100)]
        public string Name { get; set; }

        [MinValueAttribute(0)]
        [MaxValueAttribute(100)]
        public int Age { get; set; }

        public Person (int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

    }
}
