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
    public class UpdateAsync_Validation_Should : TestBase
    {
        [Theory]
        [InlineData(0, "asd", "asd", 1)]
        [InlineData(1, null, "asd", 1)]
        [InlineData(1, "", "asd", 1)]
        [InlineData(1, "   ", "asd", 1)]
        [InlineData(1, "as", "asd", 1)]
        [InlineData(1, "asd", null, 1)]
        [InlineData(1, "asd", "", 1)]
        [InlineData(1, "asd", "   ", 1)]
        [InlineData(1, "asd", "as", 1)]
        [InlineData(1, "asd", "asd", 2)]
        public async Task Throw_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure modified = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            Func<Task> task = async () =>
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .UpdateAsync(modified)
                   .ConfigureAwait(false);
            };

            // Assert
            task.Should().ThrowExactly<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        public UpdateAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}