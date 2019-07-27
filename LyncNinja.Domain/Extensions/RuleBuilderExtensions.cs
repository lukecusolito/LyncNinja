using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace LyncNinja.Domain.Extensions
{
    public static class RuleBuilderExtensions
    {
        #region Fields
        private const string URL_REGEX = @"^[a-zA-Z0-9].*(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:\/?#[\]@!\$&'\(\)\*\+,;=.]+[\/]?$";
        private const string HTTP_SCHEME = "http://";
        private const string HTTPS_SCHEME = "https://";
        #endregion

        public static IRuleBuilder<T, string> IsUrl<T>(this IRuleBuilder<T, string> ruleBuilder) =>
               ruleBuilder
                .NotEmpty()
                .WithMessage("Please enter a URL")
                .Must(BeAValidUrl)
                .WithMessage("The URL provided is invalid. Please provide a valid URL.");

        #region Private Methods
        /// <summary>
        /// Validates a URL is of a valid format
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static bool BeAValidUrl(string url)
        {
            if (!Regex.IsMatch(url, URL_REGEX, RegexOptions.IgnoreCase))
                return false;

            if (!url.StartsWith(HTTP_SCHEME, StringComparison.OrdinalIgnoreCase) || !url.StartsWith(HTTPS_SCHEME, StringComparison.OrdinalIgnoreCase))
                url = HTTP_SCHEME + url;

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
                return (uri.Scheme == Uri.UriSchemeHttp ||
                        uri.Scheme == Uri.UriSchemeHttps);

            return false;
        }
        #endregion
    }
}
