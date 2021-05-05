namespace DigitalLibrary.MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class DeleteAsync_Validation_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenInputIsInvalid()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure();

            // Action
            Func<Task> action = async () => await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .DeleteAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        [Fact]
        public async Task Throw_WhenInputIsNull()
        {
            // Arrange

            // Action
            Func<Task> action = async () => await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .DeleteAsync(null)
               .ConfigureAwait(false);

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        public DeleteAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}