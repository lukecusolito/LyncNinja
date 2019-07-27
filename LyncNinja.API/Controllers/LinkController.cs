using LyncNinja.Domain.Enumerations;
using LyncNinja.Domain.Models;
using LyncNinja.Domain.Models.Configuration;
using LyncNinja.Domain.Models.Dto;
using LyncNinja.Domain.Models.Request;
using LyncNinja.Services.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LyncNinja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        #region Fields
        private readonly IDataService _dataService;

        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor 
        public LinkController(IOptions<AppSettings> appSettings, IDataService dataService)
        {
            _appSettings = appSettings.Value;
            _dataService = dataService;
        }
        #endregion

        /// <summary>
        /// Generates a short URL
        /// </summary>
        /// <param name="request"></param>
        /// <returns>LinkedResourceDto</returns>
        [HttpPost]
        public IActionResult CreateLink([FromBody]CreateLinkRequest request)
        {
            // Retrieve existing 
            var linkedResource = request.ToDto();
            var existingLink = _dataService.LinkedResource.Get(request.Url);

            // If there is no existing resource create a new one
            if (existingLink == null)
                linkedResource = _dataService.LinkedResource.Save(linkedResource);
            else
                linkedResource = existingLink;

            // Generate the Key and EncodedUrl properties
            linkedResource.EncodeKey(_appSettings.EncodedUrlBase);

            return Ok(linkedResource);
        }

        /// <summary>
        /// Retrieves a stored URL using an encoded key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>LinkedResourceDto</returns>
        [HttpGet]
        [Route("{key}")]
        public IActionResult RetrieveLink([FromRoute]string key)
        {
            var linkedResource = new LinkedResourceDto { Key = key };

            // Generate the Id from the supplied Key
            linkedResource.DecodeKey();

            linkedResource = _dataService.LinkedResource.Get(linkedResource.Id);

            if (linkedResource == null)
                return BadRequest(new ErrorResponse(ErrorCode.INVALID_LINK));

            return Ok(linkedResource);
        }
    }
}