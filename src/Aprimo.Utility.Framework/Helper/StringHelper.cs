using System;
using System.Text.RegularExpressions;

namespace Aprimo.Utility.Framework.Helper
{
    /// <summary>
    /// StringHelper
    /// </summary>
    public static class StringHelper
    {
        #region Constants

        /// <summary>
        /// ConstZero has a value 'String.Empty'
        /// </summary>
        private const string ZERO = " ";

        /// <summary>
        /// ConstOne has a value 'one'
        /// </summary>
        private const string ONE = "one ";

        /// <summary>
        /// ConstTwo has a value 'two'
        /// </summary>
        private const string TWO = "two ";

        /// <summary>
        /// ConstThree has a value 'three'
        /// </summary>
        private const string THREE = "three ";

        /// <summary>
        /// ConstFour has a value 'four'
        /// </summary>
        private const string FOUR = "four ";

        /// <summary>
        /// ConstFive has a value 'five'
        /// </summary>
        private const string FIVE = "five ";

        /// <summary>
        /// ConstSix has a value 'six'
        /// </summary>
        private const string SIX = "six ";

        /// <summary>
        /// ConstSeven has a value 'seven'
        /// </summary>
        private const string SEVEN = "seven ";

        /// <summary>
        /// constEight has a value 'eight'
        /// </summary>
        private const string EIGHT = "eight ";

        /// <summary>
        /// ConstNine has a value 'nine'
        /// </summary>
        private const string NINE = "nine ";

        /// <summary>
        /// ConstTen has a value 'ten'
        /// </summary>
        private const string TEN = "ten ";

        /// <summary>
        /// ConstEleven has a value 'eleven'
        /// </summary>
        private const string ELEVEN = "eleven ";

        /// <summary>
        /// ConstTwelve has a value 'twelve'
        /// </summary>
        private const string TWELVE = "twelve ";

        /// <summary>
        /// ConstThirteen has a value 'thirteen'
        /// </summary>
        private const string THIRTEEN = "thirteen ";

        /// <summary>
        /// ConstFourteen has a value 'fourteen'
        /// </summary>
        private const string FOURTEEN = "fourteen ";

        /// <summary>
        /// ConstFifteen has a value 'fifteen'
        /// </summary>
        private const string FIFTEEN = "fifteen ";

        /// <summary>
        /// ConstSixteen has a value 'sixteen'
        /// </summary>
        private const string SIXTEEN = "sixteen ";

        /// <summary>
        /// ConstSeventeen has a value 'seventeen'
        /// </summary>
        private const string SEVENTEEN = "seventeen ";

        /// <summary>
        /// ConstEighteen has a value 'eighteen'
        /// </summary>
        private const string EIGHTEEN = "eighteen ";

        /// <summary>
        /// ConstNineteen has a value 'nineteen'
        /// </summary>
        private const string NINETEEN = "nineteen ";

        /// <summary>
        /// ConstTwenty has a value 'twenty'
        /// </summary>
        private const string TWENTY = "twenty ";

        /// <summary>
        /// ConstThirty has a value 'thirty'
        /// </summary>
        private const string THIRTY = "thirty ";

        /// <summary>
        /// ConstFourty has a value 'fourty'
        /// </summary>
        private const string FOURTY = "fourty ";

        /// <summary>
        /// FIFTY has a value 'fifty'
        /// </summary>
        private const string FIFTY = "fifty ";

        /// <summary>
        /// SIXTY has a value 'sixty'
        /// </summary>
        private const string SIXTY = "sixty ";

        /// <summary>
        /// SEVENTY has a value 'seventy'
        /// </summary>
        private const string SEVENTY = "seventy ";

        /// <summary>
        /// EIGHTY has a value 'eighty'
        /// </summary>
        private const string EIGHTY = "eighty ";

        /// <summary>
        /// NINETY has a value 'ninety'
        /// </summary>
        private const string NINETY = "ninety ";

        /// <summary>
        /// HUNDRED has a value 'hundred'
        /// </summary>
        private const string HUNDRED = "hundred ";

        /// <summary>
        /// THOUSAND has a value 'thousand'
        /// </summary>
        private const string THOUSAND = "thousand ";

        /// <summary>
        /// MILLION has a value 'million'
        /// </summary>
        private const string MILLION = "million ";

        /// <summary>
        /// OUT_OF_SCOPE has a value 'Wow, it makes a lot of money!'
        /// </summary>
        private const string OUT_OF_SCOPE = "Wow, it makes a lot of money! ";

        /// <summary>
        /// AND has a value ' and '
        /// </summary>
        private const string AND = "and ";

        /// <summary>
        /// RUPEES has a value 'INR'
        /// </summary>
        private const string RUPEES = "rupees ";

        /// <summary>
        /// PAISA has a value 'paisa '
        /// </summary>
        private const string PAISA = "paisa ";

        /// <summary>
        /// ONLY has a value 'only.'
        /// </summary>
        private const string ONLY = "only.";

        #endregion

        #region Public methods

        /// <summary>
        /// Trims the spaces.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string TrimSpaces(this string str)
        {
            return TrimSpacesRegex.Replace(str, " ").Trim();
        }

        /// <summary>
        /// Removes the special characters for combo box.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static string RemoveSpecialCharactersForComboBox(this string str)
        {
            return RemoveSpecialCharactersForComboBoxRegex.Replace(str, "|");
        }

        /// <summary>
        /// Convert2s the bytes integer to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Convert2BytesIntegerToString(this int value)
        {
            var firstChar = (char)((value & 0xFF00) >> 8);
            var secondChar = (char)(value & 0xFF);
            return string.Concat(firstChar, secondChar);
        }

        /// <summary>
        /// Converts the string to2 bytes integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static short ConvertStringTo2BytesInteger(this string value)
        {
            char firstChar = value[0];
            char secondChar = value[1];
            return (short)((firstChar << 8) + (secondChar & 0xFF));
        }

        /// <summary>
        /// To the upper first.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToUpperFirst(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1).ToLower();
        }

        /// <summary>
        /// This method converts the integer value to the English words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string CurrencyToWords(this string number)
        {
            int c = number.Length;
            const string decimalSeperator = ".";
            number = number.Replace(",", string.Empty);

            int decimalPlace = number.IndexOf(decimalSeperator, StringComparison.CurrentCulture);
            String wholenumber; String paisa;
            if (decimalPlace < 0)
            {
                decimalPlace = 0;
                wholenumber = number;
                paisa = string.Empty;
            }
            else
            {
                wholenumber = number.Substring(0, decimalPlace);
                paisa = number.Substring(decimalPlace + 1);
            }

            int numberLength = wholenumber.Length;
            string rupeeword = GetWords(numberLength, number);

            if (decimalPlace != 0)
            {
                numberLength = paisa.Length;
                if (numberLength == 1)
                {
                    numberLength = 2;
                    paisa += "0";
                }
                string paisaword = GetWords(numberLength, paisa);
                if (paisaword != ZERO)
                {
                    return string.Format("{0}{1}{2}{3}{4}{5}", rupeeword, RUPEES, AND, paisaword, PAISA, ONLY);
                }

                return string.Format("{0}{1}", rupeeword, ONLY);
            }

            return string.Format("{0}{1}", rupeeword, ONLY); ;
        }

        /// <summary>
        /// This method converts the integer value to the number of digit as required.
        /// </summary>
        /// <param name="value">Integer Value</param>
        /// <param name="numberOfDigit">Number of digit to convert</param>
        /// <returns></returns>
        public static String ConvertIntegerToNumberOfDigitRequired(int value, int numberOfDigit)
        {
            String digitInteger = value.ToString();

            while (digitInteger.Length != numberOfDigit && digitInteger.Length < numberOfDigit)
            {
                digitInteger = "0" + digitInteger;
            }

            return digitInteger;
        }

        /// <summary>
        /// Converts the integer to number of digit required.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="numberOfDigit">The number of digit.</param>
        /// <returns></returns>
        public static String ConvertDoubleToNumberOfDigitRequired(double value, int numberOfDigit)
        {
            String digitInteger = value.ToString();

            while (digitInteger.Length != numberOfDigit && digitInteger.Length < numberOfDigit)
            {
                digitInteger = "0" + digitInteger;
            }

            return digitInteger;
        }

        /// <summary>
        /// Camels the case to human readable case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string CamelCaseToHumanReadableCase(this string text)
        {
            Regex regEx = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return regEx.Replace(text, " ");
        }

		public static string PascalCaseToPrettyString(this string text)
        {
            return Regex.Replace(text, @"(\B[A-Z]|[0-9]+)", " $1");
        }
		
        #endregion

        #region Private methods

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex TrimSpacesRegex = new Regex(@"\s\s+", RegexOptions.Compiled);

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex RemoveSpecialCharactersForComboBoxRegex =
            new Regex(@"[\/]", RegexOptions.Compiled);

        /// <summary>
        /// This method word for the given integer.
        /// </summary>
        /// <param name="wn1">The WN1.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static string GetWords(int wn1, String number)
        {
            String result = string.Empty;
            switch (wn1)
            {
                // Ones
                case 1:
                    result = Ones(number.Substring(0, wn1));
                    break;

                // Tens
                case 2:
                    result = Tens(number.Substring(0, wn1));
                    break;

                // Hundreds
                case 3:
                    result = Ones(number.Substring(0, 1)) + HUNDRED + Tens(number.Substring(1, 2));
                    break;

                // Thousands
                case 4:
                    if (!string.IsNullOrEmpty(Tens(number.Substring(0, 1))))
                    {
                        result = result + Tens(number.Substring(0, 1)) + THOUSAND;
                    }

                    if (!string.IsNullOrEmpty(Ones(number.Substring(1, 1))))
                    {
                        result = result + Ones(number.Substring(1, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(2, 2));
                    break;

                // Ten thousands
                case 5:
                    if (!string.IsNullOrEmpty(Tens(number.Substring(0, 2))))
                    {
                        result = result + Tens(number.Substring(0, 2)) + THOUSAND;
                    }

                    if (!string.IsNullOrEmpty(Ones(number.Substring(2, 1))))
                    {
                        result = result + Ones(number.Substring(2, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(3, 2));
                    break;

                // Hundred thousands
                case 6:
                    result = Ones(number.Substring(0, 1)) + HUNDRED;
                    result = result + Tens(number.Substring(1, 2)) + THOUSAND;
                    if (!string.IsNullOrEmpty(Ones(number.Substring(3, 1))))
                    {
                        result = result + Ones(number.Substring(3, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(4, 2));
                    break;

                // Million
                case 7:
                    result = Ones(number.Substring(0, 1)) + MILLION;
                    if (Ones(number.Substring(1, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(1, 1)) + HUNDRED;
                    }

                    if (Tens(number.Substring(2, 2)) != null)
                    {
                        result = result + Tens(number.Substring(2, 2)) + THOUSAND;
                    }

                    if (Ones(number.Substring(4, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(4, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(5, 2));
                    break;

                // Ten millions
                case 8:
                    result = Tens(number.Substring(0, 2)) + MILLION;
                    if (Ones(number.Substring(2, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(2, 1)) + HUNDRED;
                    }

                    if (Tens(number.Substring(3, 2)) != null)
                    {
                        result = result + Tens(number.Substring(3, 2)) + THOUSAND;
                    }

                    if (Ones(number.Substring(5, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(5, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(6, 2));
                    break;

                // Hundred millions
                case 9:
                    if (Ones(number.Substring(0, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(0, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(1, 2)) + MILLION;
                    if (Ones(number.Substring(3, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(3, 1)) + HUNDRED;
                    }

                    if (Tens(number.Substring(4, 2)) != null)
                    {
                        result = result + Tens(number.Substring(4, 2)) + THOUSAND;
                    }

                    if (Ones(number.Substring(6, 1)) != ZERO)
                    {
                        result = result + Ones(number.Substring(6, 1)) + HUNDRED;
                    }

                    result = result + Tens(number.Substring(7, 2));
                    break;
                case 10:
                    result = OUT_OF_SCOPE;
                    break;
                case 11:
                    result = OUT_OF_SCOPE;
                    break;
                case 12:
                    result = OUT_OF_SCOPE;
                    break;
                default:
                    result = OUT_OF_SCOPE;
                    break;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private static string Ones(String digit)
        {
            int len = digit.Length;
            int digt = Convert.ToInt32(digit);
            String name = string.Empty;
            switch (digt)
            {
                case 1:
                    name = ONE;
                    break;
                case 2:
                    name = TWO;
                    break;
                case 3:
                    name = THREE;
                    break;
                case 4:
                    name = FOUR;
                    break;
                case 5:
                    name = FIVE;
                    break;
                case 6:
                    name = SIX;
                    break;
                case 7:
                    name = SEVEN;
                    break;
                case 8:
                    name = EIGHT;
                    break;
                case 9:
                    name = NINE;
                    break;
                case 0:
                    name = ZERO;
                    break;
            }

            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        private static string Tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = TEN;
                    break;
                case 11:
                    name = ELEVEN;
                    break;
                case 12:
                    name = TWELVE;
                    break;
                case 13:
                    name = THIRTEEN;
                    break;
                case 14:
                    name = FOURTEEN;
                    break;
                case 15:
                    name = FIFTEEN;
                    break;
                case 16:
                    name = SIXTEEN;
                    break;
                case 17:
                    name = SEVENTEEN;
                    break;
                case 18:
                    name = EIGHTEEN;
                    break;
                case 19:
                    name = NINETEEN;
                    break;
                case 20:
                    name = TWENTY;
                    break;
                case 30:
                    name = THIRTY;
                    break;
                case 40:
                    name = FOURTY;
                    break;
                case 50:
                    name = FIFTY;
                    break;
                case 60:
                    name = SIXTY;
                    break;
                case 70:
                    name = SEVENTY;
                    break;
                case 80:
                    name = EIGHTY;
                    break;
                case 90:
                    name = NINETY;
                    break;

                default:
                    if (digt > 0 && digt <= 9)
                    {
                        name = Ones(digit);
                    }
                    else if (digt > 9 && digt <= 99)
                    {
                        name = Tens(digit.Substring(0, 1) + "0") + Ones(digit.Substring(1));
                    }

                    break;
            }

            return name;
        }

        #endregion
    }
}
