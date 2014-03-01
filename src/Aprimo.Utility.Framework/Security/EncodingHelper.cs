using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Framework.Security
{
    public static class EncodingHelper
    {
        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ToBase64String(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// To the byte array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string input)
        {
            input = input.Replace('-', '+').Replace('_', '/');
            int pad = 4 - (input.Length % 4);
            pad = pad > 2 ? 0 : pad;
            input = input.PadRight(input.Length + pad, '=');
            return Convert.FromBase64String(input);
        }
    }
}
