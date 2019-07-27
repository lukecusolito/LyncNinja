using LyncNinja.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LyncNinja.Tests.UnitTests.Common.Utilities
{
    /// <summary>
    /// @Feature: String Extension
    /// </summary>
    /// <remarks>
    /// As a developer
    /// I want string extensions
    /// So I am able to simplify development
    /// </remarks>
    [TestClass]
    public class StringExtensionTests
    {
        /// <summary>
        /// @Scenario: Convert string to camel case
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I convert a string to camel case
        /// And the string is in pascal case
        /// Then I expect the string to be converted to camel case
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ConvertStringToCamelCase()
        {
            // Arrange
            var expected = "someString";
            var str = "SomeString";

            // Act
            var actual = str.ToCamelCase();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// @Scenario: Convert string to camel case that is already in camel case
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I convert a string to camel case
        /// And the string is in camel case
        /// Then I expect the string to remain in camel case
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ConvertStringToCamelCaseThatIsAlreadyInCamelCase()
        {
            // Arrange
            var expected = "someString";
            var str = "someString";

            // Act
            var actual = str.ToCamelCase();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
