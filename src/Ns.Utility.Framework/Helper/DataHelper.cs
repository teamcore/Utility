using System;
using System.Collections.Generic;
using System.Text;
using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Helper
{
    /// <summary>
    /// Static helper class used by the factories when getting 
    /// data from ADO.NET objects (i.e. IDataReader)
    /// </summary>
    public static class DataHelper
    {
        private const string MIN_SQL_DATE_VALUE = "1/1/1753";

        #region Static Data Helper Methods

        public static DateTime GetDateTime(object value)
        {
            var dateValue = DateTime.MinValue;
            if ((value != null) && (value != DBNull.Value))
            {
                if ((DateTime)value > DateTime.Parse(MIN_SQL_DATE_VALUE))
                {
                    dateValue = (DateTime)value;
                }
            }
            return dateValue;
        }

        public static DateTime? GetNullableDateTime(object value)
        {
            DateTime? dateTimeValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {
                DateTime dbDateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dbDateTimeValue))
                {
                    dateTimeValue = dbDateTimeValue;
                }
            }
            return dateTimeValue;
        }

        public static int GetInteger(object value)
        {
            int integerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                int.TryParse(value.ToString(), out integerValue);
            }
            return integerValue;
        }

        public static int? GetNullableInteger(object value)
        {
            int? integerValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {
                int parseIntegerValue = 0;
                if (int.TryParse(value.ToString(), out parseIntegerValue))
                {
                    integerValue = parseIntegerValue;
                }
            }
            return integerValue;
        }

        public static decimal GetDecimal(object value)
        {
            decimal decimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decimalValue);
            }
            return decimalValue;
        }

        public static decimal? GetNullableDecimal(object value)
        {
            decimal? decimalValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal parseDecimalValue = 0;
                if (decimal.TryParse(value.ToString(), out parseDecimalValue))
                {
                    decimalValue = parseDecimalValue;
                }
            }
            return decimalValue;
        }

        public static double GetDouble(object value)
        {
            double doubleValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                double.TryParse(value.ToString(), out doubleValue);
            }
            return doubleValue;
        }

        public static double? GetNullableDouble(object value)
        {
            double? doubleValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {
                double parseDoubleValue = 0;
                if (double.TryParse(value.ToString(), out parseDoubleValue))
                {
                    doubleValue = parseDoubleValue;
                }
            }

            return doubleValue;
        }

        public static Guid GetGuid(object value)
        {
            var guidValue = Guid.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                try
                {
                    guidValue = new Guid(value.ToString());
                }
                catch
                {
                    // really do nothing, because we want to return a value for the guid = Guid.Empty;
                }
            }
            return guidValue;
        }

        public static Guid? GetNullableGuid(object value)
        {
            Guid? guidValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {
                try
                {
                    guidValue = new Guid(value.ToString());
                }
                catch
                {
                    // really do nothing, because we want to return a value for the guid = null;
                }
            }
            return guidValue;
        }

        public static string GetString(object value)
        {
            var stringValue = string.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                stringValue = value.ToString().Trim();
            }
            return stringValue;
        }

        public static bool GetBoolean(object value)
        {
            var bReturn = false;
            if (value != null && value != DBNull.Value)
            {
                bReturn = Convert.ToBoolean(value);
            }
            return bReturn;
        }

        public static bool? GetNullableBoolean(object value)
        {
            bool? bReturn = null;
            if (value != null && value != DBNull.Value)
            {
                bReturn = (bool)value;
            }

            return bReturn;
        }

        public static T GetEnumValue<T>(object databaseValue) where T : struct
        {
            T enumValue = default(T);

            if (databaseValue != null && databaseValue.ToString().Length > 0)
            {
                var parsedValue = Enum.Parse(typeof(T), databaseValue.ToString());
                if (parsedValue != null)
                {
                    enumValue = (T)parsedValue;
                }
            }

            return enumValue;
        }

        public static byte[] GetByteArrayValue(object value)
        {
            byte[] arrayValue = null;
            if (value != null && value != DBNull.Value)
            {
                arrayValue = (byte[])value;
            }
            return arrayValue;
        }

        public static string EntityListToDelimited<T>(IList<T> entities) where T : Entity
        {
            var builder = new StringBuilder(20);
            if (entities != null)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(",");
                    }
                    builder.Append(entities[i].Id.ToString());
                }
            }
            return builder.ToString();
        }

        #endregion
    }
}
