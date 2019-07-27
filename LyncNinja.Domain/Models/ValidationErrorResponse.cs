using LyncNinja.Domain.Enumerations;
using System.Collections.Generic;

namespace LyncNinja.Domain.Models
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public ValidationErrorResponse()
        {
            base.AddError(ErrorCode.REQUEST_VALIDATION_ERRORS);
        }

        public List<ValidationError> ValidationErrors { get; set; }
    }
}
