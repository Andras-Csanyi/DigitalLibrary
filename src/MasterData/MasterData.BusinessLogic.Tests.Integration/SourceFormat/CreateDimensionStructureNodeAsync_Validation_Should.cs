namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class CreateDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        public CreateDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(
            testOutputHelper)
        {
        }

        [Fact]
        public async Task Throw_WhenInputIsNull()
        {
            // Act
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .CreateDimensionStructureNodeAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Theory]
        [ClassData(typeof(Create_DimensionStructureNode_Validation_TestData))]
        public async Task Throw_WhenInputValue_IsInvalid(long Id, int IsActive)
        {
            // Arrange
            DimensionStructureNode node = new DimensionStructureNode
            {
                Id = Id,
                IsActive = IsActive,
            };

            // Action
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .CreateDimensionStructureNodeAsync(node)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
