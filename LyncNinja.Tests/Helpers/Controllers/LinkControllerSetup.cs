using LyncNinja.API.Controllers;
using LyncNinja.Domain.Models.Configuration;
using LyncNinja.Services.Interfaces.Data;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace LyncNinja.Tests.Helpers.Controllers
{
    public class LinkControllerSetup
    {
        public LinkController Scope { get { return new LinkController(Mock_AppSettings, Mock_DataService); } }

        public IOptions<AppSettings> Mock_AppSettings { get; set; } = Substitute.For<IOptions<AppSettings>>();
        public IDataService Mock_DataService { get; set; } = Substitute.For<IDataService>();
    }
}
