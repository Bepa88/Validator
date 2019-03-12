using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinLengthProperty_LessAttributes()
        {
            var model = new ClassWithMinLengthProperty
            {
                MinLengthProperty = ""
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MinLengthProperty_MoreAttributes()
        {
            var model = new ClassWithMinLengthProperty
            {
                MinLengthProperty = "Test"
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void MaxLengthProperty_LessAttributes()
        {
            var model = new ClassWithMaxLengthProperty
            {
                MaxLengthProperty = "Test"
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MaxLengthProperty_MoreAttributes()
        {
            var model = new ClassWithMaxLengthProperty
            {
                MaxLengthProperty = "TestTest"
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void MinValueProperty_LessAttributes()
        {
            var model = new ClassWithMinValueProperty
            {
                MinValueProperty = -1
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MinValueProperty_MoreAttributes()
        {
            var model = new ClassWithMinValueProperty
            {
                MinValueProperty = 30
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MaxValueProperty_LessAttributes()
        {
            var model = new ClassWithMaxValueProperty
            {
                MaxValueProperty = 30
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void MaxValueProperty_MoreAttributes()
        {
            var model = new ClassWithMaxValueProperty
            {
                MaxValueProperty = 130
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void RequiredProperty_IsNotEmpty()
        {
            var model = new ClassWithRequiredProperty
            {
                RequiredProperty = "test"
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RequiredProperty_IsEmpty()
        {
            var model = new ClassWithRequiredProperty
            {
                RequiredProperty = null
            };

            var result = (new Validator()).IsValidate(model);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RequiredAndMinLengnthProperty()
        {
            var model = new ClassWithRequiredAndMinLengnthProperty
            {
                Property = "testtesttest"
            };

            var result = new Validator().IsValidate(model);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AllProperty_IsValid()
        {
            var model = new Person(1, "Vera", 30);

            var result = new Validator().IsValidate(model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AllProperty_IsNotValid()
        {
            var model = new Person(1, "Vera", 130);

            var result = new Validator().IsValidate(model);

            Assert.IsFalse(result);
        }
    }
}
