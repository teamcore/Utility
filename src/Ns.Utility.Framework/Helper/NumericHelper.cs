using System;

namespace Ns.Utility.Framework.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class NumericHelper
    {
        /// <summary>
        /// Returns the float part of the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static decimal FloatPart(decimal number) {
            return number - Math.Truncate(number);
        }

        /// <summary>
        /// Returns the integer part of the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int IntegerPart(decimal number)
        {
            if (number < 0) {
                return (int)(Math.Truncate(number) - 1);
            }
            return (int)Math.Truncate(number);
        }

        /// <summary>
        /// Truncates the decimal number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digits">The digits.</param>
        /// <returns></returns>
        public static decimal TruncateDecimalNumber(decimal number, int digits) {
            decimal stepper = (decimal)(Math.Pow(10.0, digits));
            int temp = (int)(stepper * number);
            return temp / stepper;
        }

        /// <summary>
        /// Truncates the decimal number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digits">The digits.</param>
        /// <returns></returns>
        public static double TruncateDecimalNumber(double number, int digits)
        {
            double stepper = Math.Pow(10.0, digits);
            int temp = (int)(stepper * number);
            return temp / stepper;
        }

        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digits">The digits.</param>
        /// <returns></returns>
        public static double RoundOff(double number, int digits)
        {
            return Math.Round(number, digits);
        }

        /// <summary>
        /// Rounds up.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="digits">The digits.</param>
        /// <returns></returns>
        public static decimal RoundOff(decimal number, int digits)
        {
            return Math.Round(number, digits);
        }
    }
}
