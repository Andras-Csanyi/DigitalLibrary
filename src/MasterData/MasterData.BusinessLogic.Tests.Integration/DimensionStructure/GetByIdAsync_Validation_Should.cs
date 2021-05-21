namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    public class GetByIdAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenInputIsInvalid()
        {
            // Arrange
            DimensionStructure query = new DimensionStructure()
            {
                Id = 0,
            };

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetByIdAsync(query)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        [Fact]
        public async Task Throw_WhenInputIsNull()
        {
            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetByIdAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        public GetByIdAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}
