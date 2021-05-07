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
    public class InactivateValidation_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenInputObjectIsNull()
        {
            // Arrange
            DimensionStructure queryObject = null;

            // Action
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .InactivateAsync(queryObject)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        [Fact]
        public async Task Throw_WhenInputIdIsZero()
        {
            // Arrange
            DimensionStructure queryObject = new();

            // Action
            Func<Task> action = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .InactivateAsync(queryObject)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        public InactivateValidation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}