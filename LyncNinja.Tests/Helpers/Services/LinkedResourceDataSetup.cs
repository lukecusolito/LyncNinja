using LyncNinja.Data.EntityModels;
using LyncNinja.Services.DataService;
using LyncNinja.Tests.Helpers.Data;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LyncNinja.Tests.Helpers.Services
{
    public class LinkedResourceDataSetup
    {
        #region Constructor
        public LinkedResourceDataSetup(bool initialiseData = false)
        {
            if (initialiseData)
                Mock_LyncNinjaContext = LyncNinjaContextSetup.InitialiseLyncNinjaContext();
            else
                Mock_LyncNinjaContext = LyncNinjaContextSetup.InitialiseEmptyLyncNinjaContext();
        }
        #endregion

        public LinkedResourceData Scope { get { return new LinkedResourceData(Mock_LyncNinjaContext, Mock_Logger); } }

        public LyncNinjaContext Mock_LyncNinjaContext { get; }
        public ILogger<LinkedResourceData> Mock_Logger { get; set; } = Substitute.For<ILogger<LinkedResourceData>>();
    }
}
