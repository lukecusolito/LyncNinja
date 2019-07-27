using LyncNinja.Services.Interfaces.Data;

namespace LyncNinja.Services.DataService
{
    public class DataService : IDataService
    {
        #region Constructor
        public DataService(ILinkedResourceData linkedResourceData)
        {
            LinkedResource = linkedResourceData;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Retrieves data functions for the LinkedResource object
        /// </summary>
        public ILinkedResourceData LinkedResource { get; internal set; }
        #endregion
    }
}
