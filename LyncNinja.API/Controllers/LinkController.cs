using System;
using LyncNinja.Domain.Models.Configuration;
using LyncNinja.Domain.Models.Request;
using LyncNinja.Services.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LyncNinja.API.Controllers
{
    public class LinkController : Controller
    {
        private IOptions<AppSettings> mock_AppSettings;
        private IDataService mock_DataService;

        public LinkController(IOptions<AppSettings> mock_AppSettings, IDataService mock_DataService)
        {
            this.mock_AppSettings = mock_AppSettings;
            this.mock_DataService = mock_DataService;
        }

        public IActionResult CreateLink(CreateLinkRequest request)
        {
            throw new NotImplementedException();
        }

        public IActionResult RetrieveLink(string request)
        {
            throw new NotImplementedException();
        }
    }
}