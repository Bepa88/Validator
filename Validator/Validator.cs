using System;
using System.Reflection;

namespace Validator
{
    public class Validator
    {
        public bool IsValidate(object model)
        {
            var type = model.GetType();

            
            foreach (PropertyInfo property in type.GetProperties())
            {
                //MinValueAttribute
                var minValAttr = property.GetCustomAttribute<MinValueAttribute>();
                if(minValAttr != null)
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
                //foreach (MinValueAttribute value in
                //       property.GetCustomAttributes(typeof(MinValueAttribute)))
                //{
                //    if ((int)property.GetValue(model, null) < value.Value)
                //    {
                //        return false;
                //    }
                //    else
                //        return true;
                //}


                //MaxValueAttribute

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

                //foreach (MaxValueAttribute value in
                //       property.GetCustomAttributes(typeof(MaxValueAttribute)))
                //{
                //    if ((int)property.GetValue(model, null) > value.Value)
                //    {
                //        return false;
                //    }
                //    else
                //        return true;
                //}


                //MinLengthAttribute

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

                //foreach (MinLengthAttribute value in
                //       property.GetCustomAttributes(typeof(MinLengthAttribute)))
                //{
                //    if ((property.GetValue(model, null)).ToString().Length < value.Length)
                //    {
                //        return false;
                //    }
                //    else
                //        return true;
                //}


                //MaxLengthAttribute

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

                //foreach (MaxLengthAttribute value in
                //       property.GetCustomAttributes(typeof(MaxLengthAttribute)))
                //{
                //    if ((property.GetValue(model, null)).ToString().Length < value.Length)
                //    {
                //        return true;
                //    }
                //    else
                //        return false;
                //}


                //RequiredAttribute
                foreach (RequiredAttribute value in
                       property.GetCustomAttributes(typeof(RequiredAttribute)))
                {
                    return property.GetValue(model, null) != null;
                }
            }

            return true;
        }
    }

}
