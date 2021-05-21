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
    public class AppendDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        public AppendDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Theory]
        [ClassData(typeof(AppendDimensionStructureNodeAsync_InputValidation_TestData))]
        public async Task Throw_WhenInputIsInvalid(
            long sourceFormatId,
            long parentId,
            long toBeAdded)
        {
            // Act
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AppendDimensionStructureNodeToTreeAsync(toBeAdded, parentId, sourceFormatId)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        [Theory]
        [ClassData(typeof(AppendDimensionStructureNodeAsync_NoSuchObject_TestData))]
        public async Task Throw_WhenNoSuchSourceFormatOrDimensionStructureNode(
            long sourceFormatId,
            bool isSourceFormatExist,
            long parentId,
            bool isParentExist,
            long toBeAddedId,
            bool isToBeAddedExist)
        {
            // Arrange
            long sourceFormatIdUsed = 0;
            long parentIdUsed = 0;
            long toBeAddedIdUsed = 0;

            if (isSourceFormatExist)
            {
                SourceFormat sourceFormat = await CreateSavedSourceFormatEntity().ConfigureAwait(false);
                sourceFormatIdUsed = sourceFormat.Id;
            }
            else
            {
                sourceFormatIdUsed = sourceFormatId;
            }

            if (isParentExist)
            {
                DimensionStructureNode dimensionStructureNode = await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);
                parentIdUsed = dimensionStructureNode.Id;
            }
            else
            {
                parentIdUsed = parentId;
            }

            if (isToBeAddedExist)
            {
                DimensionStructureNode dimensionStructureNode = await CreateSavedDimensionStructureNodeEntity()
                   .ConfigureAwait(false);
                toBeAddedIdUsed = dimensionStructureNode.Id;
            }
            else
            {
                toBeAddedIdUsed = toBeAddedId;
            }

            // Act
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AppendDimensionStructureNodeToTreeAsync(
                        toBeAddedIdUsed,
                        parentIdUsed,
                        sourceFormatIdUsed)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
