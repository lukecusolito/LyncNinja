using LyncNinja.Common.Utilities;
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
    public class Base64Tests
    {
        /// <summary>
        /// @Scenario: Convert string to base 64
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I convert a string to base 64
        /// Then I expect the string to be converted to base 64
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ConvertStringToBase64()
        {
            // Arrange
            var expected = "U29tZVN0cmluZw==";
            var str = "SomeString";

            // Act
            var actual = Base64.Encode(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// @Scenario: Convert base 64 string to plaintext
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I decode a base 64 string
        /// Then I expect the string tp be represented in plaintext
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ConvertBase64StringToPlaintext()
        {
            // Arrange
            var expected = "SomeString";
            var str = "U29tZVN0cmluZw==";

            // Act
            var actual = Base64.Decode(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// @Scenario: Convert base 64 string to plaintext when padding is missing
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I decode a base 64 string
        /// And the base 64 string is missing padding
        /// Then I expect the string tp be represented in plaintext
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void ConvertBase64StringToPlaintextWhenPaddingIsMissing()
        {
            // Arrange
            var expected = "SomeString";
            var str = "U29tZVN0cmluZw";

            // Act
            var actual = Base64.Decode(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
