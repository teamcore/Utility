using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Aprimo.Utility.Framework.Helper
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(this Enum enumeration)
        {
            try
            {
                var attributes = (DescriptionAttribute[])enumeration.GetType().GetField(enumeration.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : enumeration.ToString().PascalCaseToPrettyString();
            }
            catch (Exception exception)
            {
                return enumeration.ToString().PascalCaseToPrettyString();
            }
        }

        public static IList<EnumKeyValue<int>> ToEnumList<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            Type enumType = typeof(TEnum);

            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("TEnum must be of type System.Enum");
            }

            var values = from TEnum e in Enum.GetValues(enumType)
                         let underlyingType = Enum.GetUnderlyingType(e.GetType())
                         let value = Convert.ChangeType(e, underlyingType)
                         select new EnumKeyValue<int>((int)Convert.ChangeType(e, underlyingType), (e as Enum).GetEnumDescription());
            return values.ToList();
        }
    }
}