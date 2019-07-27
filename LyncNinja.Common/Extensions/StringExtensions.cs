using System;

namespace LyncNinja.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to camel case
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);

            return str;
        }
    }
}
