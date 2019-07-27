using FluentValidation;
using LyncNinja.Domain.Extensions;
using LyncNinja.Domain.Models.Dto;
using System;

namespace LyncNinja.Domain.Models.Request
{
    public class CreateLinkRequest
    {
        #region Fields
        private const string HTTP_PREFIX = "http";
        private const string HTTP_SCHEME = "http://";
        #endregion

        #region Properties
        public string Url { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Converts the request object to a LinkedResourceDto
        /// </summary>
        /// <returns></returns>
        public LinkedResourceDto ToDto()
        {
            if (!Url.StartsWith(HTTP_PREFIX, StringComparison.OrdinalIgnoreCase))
                Url = HTTP_SCHEME + Url;

            return new LinkedResourceDto
            {
                Url = Url
            };
        }
        #endregion
    }

    public class CreateLinkRequestValidator : AbstractValidator<CreateLinkRequest>
    {
        public CreateLinkRequestValidator()
        {
            RuleFor(x => x.Url)
                .IsUrl();
        }
    }
}
