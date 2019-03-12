using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Validator
{
    public class Validator
    {
        public bool IsValidate(object model)
        {
            var type = model.GetType();
            List<bool> val = new List<bool>();

            foreach (PropertyInfo property in type.GetProperties())
            {
                var minValueAttribute = IsValidateMinValueAttribute(property, model);
                val.Add(minValueAttribute);
                var maxValueAttribute = IsValidateMaxValueAttribute(property, model);
                val.Add(maxValueAttribute);
                var minLengthAttribute = IsValidateMinLengthAttribute(property, model);
                val.Add(minLengthAttribute);
                var maxLengthAttribute = IsValidateMaxLengthAttribute(property, model);
                val.Add(maxLengthAttribute);
                var requiredAttribute = IsValidateRequiredAttribute(property, model);
                val.Add(requiredAttribute);
            }

            return val.All(x => x == true);
        }


        //MinValueAttribute
        public bool IsValidateMinValueAttribute(PropertyInfo property, object model)
        {
            var minValAttr = property.GetCustomAttribute<MinValueAttribute>();
            if (minValAttr != null)
            {
                var prop = property.GetValue(model);
                if (prop.GetType() == typeof(int))
                {
                    if ((int)prop < minValAttr.Value)
                    {
                        return false;
                    }
                    else
                        return true;

                }
            }

            return true;
        }

        //MaxValueAttribute
        public bool IsValidateMaxValueAttribute(PropertyInfo property, object model)
        {
            var maxValAttr = property.GetCustomAttribute<MaxValueAttribute>();
            if (maxValAttr != null)
            {
                var prop = property.GetValue(model);
                if (prop.GetType() == typeof(int))
                {
                    if ((int)prop > maxValAttr.Value)
                    {
                        return false;
                    }
                    else
                        return true;

                }
            }

            return true;
        }

        //MinLengthAttribute
        public bool IsValidateMinLengthAttribute(PropertyInfo property, object model)
        {
            var minLengthAttr = property.GetCustomAttribute<MinLengthAttribute>();
            if (minLengthAttr != null)
            {
                var prop = property.GetValue(model);
                if (prop.GetType() == typeof(string))
                {
                    if (prop.ToString().Length < minLengthAttr.Length)
                    {
                        return false;
                    }
                    else
                        return true;

                }
            }
            return true;
        }

        //MaxLengthAttribute
        public bool IsValidateMaxLengthAttribute(PropertyInfo property, object model)
        {
            var maxLengthAttr = property.GetCustomAttribute<MaxLengthAttribute>();
            if (maxLengthAttr != null)
            {
                var prop = property.GetValue(model);
                if (prop.GetType() == typeof(string))
                {
                    if (prop.ToString().Length < maxLengthAttr.Length)
                    {
                        return true;
                    }
                    else
                        return false;

                }
            }
            return true;
        }

        //RequiredAttribute
        public bool IsValidateRequiredAttribute(PropertyInfo property, object model)
        {
            var requiredAttribute = property.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttribute != null)
            {
                return property.GetValue(model, null) != null;
            }
            return true;
        }


    }

}
