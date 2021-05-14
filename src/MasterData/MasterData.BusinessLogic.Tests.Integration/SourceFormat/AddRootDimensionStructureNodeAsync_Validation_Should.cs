namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddRootDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        [Theory]
        [InlineData(0, 0, false, false)]
        [InlineData(1, 0, false, false)]
        [InlineData(0, 1, false, false)]
        [InlineData(1, 1, true, false)]
        [InlineData(1, 1, false, true)]
        public async Task Throw_WhenInputIsInvalid(
            long sourceFormatId,
            long dimensionStructureNodeId,
            bool doesSourceFormatExists,
            bool doesDimensionStructureNodeExist)
        {
            // Arrange
            long sourceFormatIdInTest = 0;
            long dimensionStructureNodeIdInTest = 0;

            if (doesSourceFormatExists is false)
            {
                sourceFormatIdInTest = sourceFormatId;
            }
            else
            {
                SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
                sourceFormatIdInTest = sourceFormat.Id;
            }

            if (doesDimensionStructureNodeExist is false)
            {
                dimensionStructureNodeIdInTest = dimensionStructureNodeId;
            }
            else
            {
                DimensionStructureNode dimensionStructureNode = await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);
                dimensionStructureNodeIdInTest = dimensionStructureNode.Id;
            }

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddRootDimensionStructureNodeAsync(sourceFormatIdInTest, dimensionStructureNodeIdInTest)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        public AddRootDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(
            testOutputHelper)
        {
        }
    }
}