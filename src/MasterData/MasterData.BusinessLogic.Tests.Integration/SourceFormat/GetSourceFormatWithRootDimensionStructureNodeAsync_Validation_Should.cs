namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Tests.TestData;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class GetSourceFormatWithRootDimensionStructureNodeAsync_Validation_Should : TestBase
    {
        [Theory]
        [ClassData(typeof(SourceFormat_GetSourceFormatByIdWithRootDimensionStructureNodeAsync_Validation_TestData))]
        public async Task Throw_WhenInputIsInvalid(SourceFormat queryObject)
        {
            // Arrange

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(queryObject)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }

        public GetSourceFormatWithRootDimensionStructureNodeAsync_Validation_Should(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }
    }
}