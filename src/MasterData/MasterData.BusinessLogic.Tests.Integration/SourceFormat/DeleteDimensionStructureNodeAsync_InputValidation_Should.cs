namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.Tests.TestData.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class DeleteDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        public DeleteDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(
            testOutputHelper)
        {
        }

        [Theory]
        [ClassData(typeof(DeleteDimensionStructureNodeAsync_InputValidation))]
        public async Task Throw_WhenInputIsInvalid(
            long dimensionStructureNodeId,
            long parentId,
            long sourceFormatId)
        {
            // Act
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteDimensionStructureNodeFromTreeAsync(
                        dimensionStructureNodeId,
                        parentId,
                        sourceFormatId)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
