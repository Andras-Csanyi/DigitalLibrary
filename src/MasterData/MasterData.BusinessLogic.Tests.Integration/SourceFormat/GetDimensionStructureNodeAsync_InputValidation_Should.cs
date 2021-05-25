namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class GetDimensionStructureNodeAsync_InputValidation_Should : TestBase
    {
        public GetDimensionStructureNodeAsync_InputValidation_Should(ITestOutputHelper testOutputHelper) : base(
            testOutputHelper)
        {
        }

        [Fact]
        public async Task Throw_WhenInputIsInvalid()
        {
            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .GetDimensionStructureNodeByIdAsync(0)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}
