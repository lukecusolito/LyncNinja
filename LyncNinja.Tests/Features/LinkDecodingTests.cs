using LyncNinja.Domain.Enumerations;
using LyncNinja.Domain.Models;
using LyncNinja.Domain.Models.Dto;
using LyncNinja.Tests.Helpers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;
using System.Net;

namespace LyncNinja.Tests.Features
{
    /// <summary>
    /// @Feature: Link Decoding
    /// </summary>
    /// <remarks>
    /// As a user
    /// I want to be able decode an encoded link
    /// So I am able to view the unencoded URL
    /// </remarks>
    [TestClass]
    public class LinkDecodingTests
    {
        /// <summary>
        /// @Scenario: Link is decoded
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to decode an encoded link
        /// And the decoded URL exists
        /// Then I expect the raw url to be retrieved
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkIsDecoded()
        {
            // Arrange
            var expected = new LinkedResourceDto { Id = 1, Url = "http://some.site" };
            var request = "MQ";

            var linkController = new LinkControllerSetup();
            linkController.Mock_DataService.LinkedResource.Get(Arg.Any<long>()).Returns(expected);

            // Act
            var actualResult = linkController.Scope.RetrieveLink(request);

            // Assert
            var actual = AssertOkResult(actualResult);

            Assert.AreEqual(expected.Url, actual.Url);

            linkController.Mock_DataService.LinkedResource.Received(1).Get(Arg.Is<long>(x => x == expected.Id));
        }

        /// <summary>
        /// @Scenario: Link is not decoded when key is not supplied
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to decode an encoded link
        /// And the decoded URL exists
        /// Then I expect the raw url to be retrieved
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkIsNotDecodedWhenKeyIsNotSupplied()
        {
            // Arrange
            var request = string.Empty;

            var linkController = new LinkControllerSetup();
            linkController.Mock_DataService.LinkedResource.Get(Arg.Any<long>()).Returns(x => null);

            // Act
            var actualResult = linkController.Scope.RetrieveLink(request);

            // Assert
            var actual = AssertBadRequestResult(actualResult);

            Assert.AreEqual(1, actual.Errors.Count);
            Assert.AreEqual(ErrorCode.INVALID_LINK, actual.Errors.First().ErrorCode);

            linkController.Mock_DataService.LinkedResource.Received(1).Get(Arg.Is<long>(x => x == 0));
        }

        #region Private Methods
        private LinkedResourceDto AssertOkResult(IActionResult result)
        {
            var objectResult = result as ObjectResult;

            Assert.IsNotNull(objectResult?.Value);
            Assert.AreEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
            Assert.IsInstanceOfType(objectResult.Value, typeof(LinkedResourceDto));

            return objectResult.Value as LinkedResourceDto;
        }

        private ErrorResponse AssertBadRequestResult(IActionResult result)
        {
            var objectResult = result as ObjectResult;

            Assert.IsNotNull(objectResult?.Value);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
            Assert.IsInstanceOfType(objectResult.Value, typeof(ErrorResponse));

            return objectResult.Value as ErrorResponse;
        }
        #endregion
    }
}
