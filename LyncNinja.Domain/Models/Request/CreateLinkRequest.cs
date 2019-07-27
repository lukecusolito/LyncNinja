using FluentValidation;
using LyncNinja.Domain.Extensions;

namespace LyncNinja.Domain.Models.Request
{
    public class CreateLinkRequest
    {
        public string Url { get; set; }
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
