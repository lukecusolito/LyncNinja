using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            // Act

            // Assert
            Assert.Inconclusive();
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

            // Act

            // Assert
            Assert.Inconclusive();
        }
    }
}
