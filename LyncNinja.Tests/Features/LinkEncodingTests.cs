using LyncNinja.Common.Utilities;
using LyncNinja.Domain.Models.Configuration;
using LyncNinja.Domain.Models.Dto;
using LyncNinja.Domain.Models.Request;
using LyncNinja.Tests.Helpers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LyncNinja.Tests.Features
{
    /// <summary>
    /// @Feature: Link Encoding
    /// </summary>
    /// <remarks>
    /// As a user
    /// I want to be able to create an encoded link
    /// So I am able to navigate toa URL with a shortened link
    /// </remarks>
    [TestClass]
    public class LinkEncodingTests
    {
        /// <summary>
        /// @Scenario: New link is created when link does not exist
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to have a link encoded
        /// And the link has not been previously encoded
        /// Then I expect the raw link to be persisted
        /// And I expect the raw link to be encoded
        /// And I expect to be provided an encoded link
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void NewLinkIsCreatedWhenLinkDoesNotExist()
        {
            // Arrange
            var expected = new LinkedResourceDto { Id = 1, Url = "http://some.site" };
            var expectedKey = "MQ";
            var expectedEncodedUrl = $"http://lync.ninja/{expectedKey}";

            var request = new CreateLinkRequest { Url = expected.Url };
            var encodedUrlBase = "http://lync.ninja/";

            var linkController = new LinkControllerSetup();
            linkController.Mock_AppSettings.Value.Returns(new AppSettings { EncodedUrlBase = encodedUrlBase });
            linkController.Mock_DataService.LinkedResource.Get(Arg.Any<string>()).Returns(x => null);
            linkController.Mock_DataService.LinkedResource.Save(Arg.Any<LinkedResourceDto>()).Returns(expected);

            // Act
            var actualResult = linkController.Scope.CreateLink(request);

            // Assert
            var actual = AssertOkResult(actualResult);

            Assert.AreEqual(expected.Url, actual.Url);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expectedKey, actual.Key);
            Assert.AreEqual(expectedEncodedUrl, actual.EncodedUrl);

            var decodedKey = Base64.Decode(expected.Key);
            Assert.AreEqual(expected.Id.ToString(), decodedKey);

            linkController.Mock_DataService.LinkedResource.Received(1).Get(Arg.Any<string>());
            linkController.Mock_DataService.LinkedResource.Received(1).Save(Arg.Any<LinkedResourceDto>());
        }

        /// <summary>
        /// @Scenario: Existing link is retrieved when link has been previously encoded
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to have a link encoded
        /// And the link has been previously encoded
        /// Then I expect the persisted raw link to be retrieved
        /// And I expect the raw link to be encoded
        /// And I expect to be provided an encoded link
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ExistingLinkIsRetrievedWhenLinkHasBeenPreviouslyEncoded()
        {
            // Arrange
            var expected = new LinkedResourceDto { Id = 1, Url = "http://some.site" };
            var expectedKey = "MQ";
            var expectedEncodedUrl = $"http://lync.ninja/{expectedKey}";

            var request = new CreateLinkRequest { Url = expected.Url };
            var encodedUrlBase = "http://lync.ninja/";

            var linkController = new LinkControllerSetup();
            linkController.Mock_AppSettings.Value.Returns(new AppSettings { EncodedUrlBase = encodedUrlBase });
            linkController.Mock_DataService.LinkedResource.Get(Arg.Any<string>()).Returns(expected);

            // Act
            var actualResult = linkController.Scope.CreateLink(request);

            // Assert
            var actual = AssertOkResult(actualResult);

            Assert.AreEqual(expected.Url, actual.Url);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expectedKey, actual.Key);
            Assert.AreEqual(expectedEncodedUrl, actual.EncodedUrl);

            var decodedKey = Base64.Decode(expected.Key);
            Assert.AreEqual(expected.Id.ToString(), decodedKey);

            linkController.Mock_DataService.LinkedResource.Received(1).Get(Arg.Any<string>());
            linkController.Mock_DataService.LinkedResource.Received(0).Save(Arg.Any<LinkedResourceDto>());
        }

        /// <summary>
        /// @Scenario: Link is not created when no URL is supplied
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to have a link encoded
        /// And I dont supply a URL
        /// Then I expect no link to be encoded
        /// And I expect to be notified that a URL was not supplied
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkIsNotCreatedWhenNoUrlIsSupplied()
        {
            // Arrange
            var validator = new CreateLinkRequestValidator();
            var request = new CreateLinkRequest { Url = string.Empty };

            // Act
            var actual = validator.Validate(request);

            // Assert
            Assert.AreEqual(2, actual.Errors.Count);
            Assert.AreEqual("Please enter a URL", actual.Errors.First(x => x.PropertyName == "Url").ErrorMessage);
            Assert.AreEqual("The URL provided is invalid. Please provide a valid URL.", actual.Errors.Last(x => x.PropertyName == "Url").ErrorMessage);
        }

        /// <summary>
        /// @Scenario: Link is not created when an invalid URL is supplied
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to have a link encoded
        /// And the link provided is not a valid URL
        /// Then I expect no link to be encoded
        /// And I expect to be notified that the supplied URL is invalid
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkIsNotCreatedWhenAnInvalidUrlIsSupplied()
        {
            // Arrange
            var validator = new CreateLinkRequestValidator();

            var urls = new List<string>
            {
                "http",
                "http://",
                "http://www",
                ".com",
                "SomeUrl",
                "SomeUrl.c",
                "http://someurl.##",
                "http://someurl.a",
                "1.1"
            };

            // Act
            foreach (var url in urls)
            {
                var request = new CreateLinkRequest { Url = url };

                var actual = validator.Validate(request);

                // Assert
                Assert.AreEqual(1, actual.Errors.Count);
                Assert.AreEqual("The URL provided is invalid. Please provide a valid URL.", actual.Errors.Last(x => x.PropertyName == "Url").ErrorMessage);
            }
        }

        /// <summary>
        /// @Scenario: Link is created when a valid URL is supplied
        /// </summary>
        /// <remarks>
        /// Given anyone
        /// When I request to have a link encoded
        /// And the link provided is a valid URL
        /// Then I expect a link to be encoded
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkIsCreatedWhenAValidUrlIsSupplied()
        {
            // Arrange
            var validator = new CreateLinkRequestValidator();

            var urls = new List<string>
            {
                "someurl.com",
                "someurl.co",
                "www.someurl.com",
                "http://www.someurl.com",
                "https://www.someurl.com",
                "https://www.someurl.com/",
                "https://www.someurl.com/someroute",
                "https://www.someurl.com/someroute?q=",
                "https://www.someurl.com/someroute?q=asdasd",
                "192.168.1.1",
                "1.1.1.1"
            };

            // Act
            foreach (var url in urls)
            {
                var request = new CreateLinkRequest { Url = url };

                var actual = validator.Validate(request);

                // Assert
                Assert.AreEqual(0, actual.Errors.Count);
            }
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
        #endregion
    }
}
