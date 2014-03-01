using System;

namespace Aprimo.Utility.Framework.Helper
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Checks the parameter.
        /// </summary>
        /// <param name="param">The param.</param>
        /// <param name="checkForNull">if set to <c>true</c> [check for null].</param>
        /// <param name="checkIfEmpty">if set to <c>true</c> [check if empty].</param>
        /// <param name="checkForCommas">if set to <c>true</c> [check for commas].</param>
        /// <param name="maxSize">Size of the max.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void CheckParameter(string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize, string paramName)
        {
            if (param == null)
            {
                if (checkForNull)
                {
                    throw new ArgumentNullException(paramName);
                }
            }
            else
            {
                param = param.Trim();
                if (checkIfEmpty && (param.Length < 1))
                {
                    throw new ArgumentException("Parameter cannot be empty", 
                        paramName);
                }
                if ((maxSize > 0) && (param.Length > maxSize))
                {
                    throw new ArgumentException("Parameter too long", 
                        paramName);
                }
                if (checkForCommas && param.Contains(","))
                {
                    throw new ArgumentException("Parameter cannot contain commas", 
                        paramName);
                }
            }
        }

        /// <summary>
        /// Checks the password parameter.
        /// </summary>
        /// <param name="param">The param.</param>
        /// <param name="maxSize">Size of the max.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void CheckPasswordParameter(string param, int maxSize, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
            if (param.Length < 1)
            {
                throw new ArgumentException("Parameter cannot be empty", 
                    paramName);
            }
            if ((maxSize > 0) && (param.Length > maxSize))
            {
                throw new ArgumentException("Parameter too long", 
                    paramName);
            }
        }

        /// <summary>
        /// Validates the parameter.
        /// </summary>
        /// <param name="param">The param.</param>
        /// <param name="checkForNull">if set to <c>true</c> [check for null].</param>
        /// <param name="checkIfEmpty">if set to <c>true</c> [check if empty].</param>
        /// <param name="checkForCommas">if set to <c>true</c> [check for commas].</param>
        /// <param name="maxSize">Size of the max.</param>
        /// <returns></returns>
        public static bool ValidateParameter(string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize)
        {
            if (param == null)
            {
                return !checkForNull;
            }
            param = param.Trim();
            return (((!checkIfEmpty || (param.Length >= 1)) && 
                ((maxSize <= 0) || (param.Length <= maxSize))) && 
                (!checkForCommas || !param.Contains(",")));
        }
    }
}
