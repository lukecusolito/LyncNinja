using LyncNinja.Domain.Models.Dto;
using LyncNinja.Tests.Helpers.Data;
using LyncNinja.Tests.Helpers.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LyncNinja.Tests.UnitTests.DataService
{
    /// <summary>
    /// @Feature: Linked Resource Data
    /// </summary>
    /// <remarks>
    /// As a developer
    /// I want to access LinkedResource data
    /// So I can utilise the entity
    /// </remarks>
    [TestClass]
    public class LinkedResourceDataTests
    {
        /// <summary>
        /// @Scenario: LinkedResource is retrieved by Id
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I request to retrieve a LinkedResource by Id
        /// And an entity exists for the supplied Id
        /// Then I expect to retrieve the entity
        /// And I expect the entity to be mapped to a DTO
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkedResourceIsRetrievedById()
        {
            // Arrange
            var id = 1;
            var expected = DbSets.LinkedResources.First(x => x.UID == id);

            var linkedResourceData = new LinkedResourceDataSetup(true);

            // Act
            var actual = linkedResourceData.Scope.Get(id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.UID, actual.Id);
        }

        /// <summary>
        /// @Scenario: LinkedResource is not retrieved by Id when no entity is found
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I request to retrieve a LinkedResource by Id
        /// And an entity does not exist for the supplied Id
        /// Then I expect no entity to be retrieved
        /// And I expect the dto to be null
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkedResourceIsNotRetrievedByIdWhenNoEntityIsFound()
        {
            // Arrange
            var id = 2508;

            var linkedResourceData = new LinkedResourceDataSetup(true);

            // Act
            var actual = linkedResourceData.Scope.Get(id);

            // Assert
            Assert.IsNull(actual);
        }

        /// <summary>
        /// @Scenario: LinkedResource is retrieved by URL
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I request to retrieve a LinkedResource by URL
        /// And an entity exists for the supplied URL
        /// Then I expect to retrieve the entity
        /// And I expect the entity to be mapped to a DTO
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkedResourceIsRetrievedByUrl()
        {
            // Arrange
            var id = 1;
            var expected = DbSets.LinkedResources.First(x => x.UID == id);
            var url = expected.Url;

            var linkedResourceData = new LinkedResourceDataSetup(true);

            // Act
            var actual = linkedResourceData.Scope.Get(url);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.UID, actual.Id);
        }

        /// <summary>
        /// @Scenario: LinkedResource is not retrieved by URL when no entity is found
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I request to retrieve a LinkedResource by URL
        /// And an entity does not exist for the supplied URL
        /// Then I expect no entity to be retrieved
        /// And I expect the dto to be null
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkedResourceIsNotRetrievedByUrlWhenNoEntityIsFound()
        {
            // Arrange
            var url = "Nope";

            var linkedResourceData = new LinkedResourceDataSetup(true);

            // Act
            var actual = linkedResourceData.Scope.Get(url);

            // Assert
            Assert.IsNull(actual);
        }

        /// <summary>
        /// @Scenario: LinkedResource is updated
        /// </summary>
        /// <remarks>
        /// Given a developer
        /// When I request to save a LinkedResource
        /// And an entity exists
        /// Then I expect the entity to be updated
        /// And I expect the entity to be mapped to a DTO
        /// </remarks>
        [TestMethod, TestCategory("1.0.0.0")]
        public void LinkedResourceIsUpdated()
        {
            // Arrange
            var expectedId = 1;
            var expectedUrl = "Some.Url";
            var linkedResourceDto = new LinkedResourceDto { Id = expectedId, Url = expectedUrl };
            var originalUrl = DbSets.LinkedResources.Single(x => x.UID == expectedId).Url;

            var linkedResourceData = new LinkedResourceDataSetup(true);

            // Act
            var actual = linkedResourceData.Scope.Save(linkedResourceDto);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedUrl, actual.Url);
            Assert.AreNotEqual(originalUrl, actual.Url);
        }
    }
}
