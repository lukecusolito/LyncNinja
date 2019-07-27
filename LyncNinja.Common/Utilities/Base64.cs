using System;
using System.Text;

namespace LyncNinja.Common.Utilities
{
    public static class Base64
    {
        /// <summary>
        /// Encodes string to Base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodes Base64 string to plaintext
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Decode(string base64EncodedData)
        {
            int mod4 = base64EncodedData.Length % 4;
            if (mod4 > 0)
                base64EncodedData += new string('=', 4 - mod4);

            try
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch { }

            return null;
        }
    }
}
