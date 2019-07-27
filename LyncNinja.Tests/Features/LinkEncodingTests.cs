using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            // Act

            // Assert
            Assert.Inconclusive();
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

            // Act

            // Assert
            Assert.Inconclusive();
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

            // Act

            // Assert
            Assert.Inconclusive();
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

            // Act

            // Assert
            Assert.Inconclusive();
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

            // Act

            // Assert
            Assert.Inconclusive();
        }
    }
}
