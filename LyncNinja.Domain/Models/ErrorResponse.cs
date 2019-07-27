using LyncNinja.Domain.Enumerations;
using LyncNinja.Domain.Resources;
using System.Collections.Generic;
using System.Linq;

namespace LyncNinja.Domain.Models
{
    public class ErrorResponse
    {
        #region Constructor(s)
        public ErrorResponse() { }

        public ErrorResponse(ErrorCode errorCode)
        {
            AddError(errorCode);
        }

        public ErrorResponse(List<ErrorCode> errorCodes)
        {
            foreach (var errorCode in errorCodes)
                AddError(errorCode);
        }
        #endregion

        #region Properties
        public List<Error> Errors { get; set; } = new List<Error>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Parses an error code, generates and adds an error to the response object
        /// </summary>
        /// <param name="errorCode"></param>
        public void AddError(ErrorCode errorCode)
        {
            if (!Errors.Any(x => x.ErrorCode == errorCode))
                Errors.Add(new Error
                {
                    ErrorCode = errorCode,
                    ErrorMessage = LocalisationMessage.GetErrorMessage(errorCode)
                });
        }

        /// <summary>
        /// Verifies if an error has been set to the response object
        /// </summary>
        /// <returns></returns>
        public bool HasErrors() =>
           Errors.Count > 0;
        #endregion
    }
}
