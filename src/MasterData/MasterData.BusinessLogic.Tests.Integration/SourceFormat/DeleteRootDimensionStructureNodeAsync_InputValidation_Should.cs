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
    public class DeleteRootDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        public DeleteRootDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }


        [Theory]
        [ClassData(typeof(DeleteRootDimensionStructureNode_InputValidation))]
        public async Task Throw_WhenInputIsInvalid(
            long dimensionStructureNodeId,
            long sourceFormatId)
        {
            // Act
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteRootDimensionStructureNodeAsync(dimensionStructureNodeId, sourceFormatId)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
