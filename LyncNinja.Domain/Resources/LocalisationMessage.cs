using LyncNinja.Domain.Enumerations;
using System.Reflection;
using System.Resources;

namespace LyncNinja.Domain.Resources
{
    public static class LocalisationMessage
    {
        /// <summary>
        /// Gets the associated error message for an error code
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <returns name="errorMessage">Error message</returns>
        public static string GetErrorMessage(ErrorCode errorCode)
        {
            ResourceManager resourceManager = new ResourceManager("LyncNinja.Domain.Resources.ErrorMessage", Assembly.GetExecutingAssembly());
            return resourceManager.GetString(errorCode.ToString());
        }
    }
}
