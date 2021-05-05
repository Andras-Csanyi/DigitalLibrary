namespace MasterData.BusinessLogic.Tests.Integration.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class AddAsync_Validation_Should : TestBase
    {
        [Theory]
        [InlineData(1, "asd", "asd", 1)]
        [InlineData(0, null, "asd", 1)]
        [InlineData(0, "", "asd", 1)]
        [InlineData(0, "   ", "asd", 1)]
        [InlineData(0, "  ", "asd", 1)]
        [InlineData(0, "as", "asd", 1)]
        [InlineData(0, "asd", null, 1)]
        [InlineData(0, "asd", "", 1)]
        [InlineData(0, "asd", "   ", 1)]
        [InlineData(0, "asd", "  ", 1)]
        [InlineData(0, "asd", "as", 1)]
        [InlineData(0, "asd", "asd", 2)]
        public async Task Throw_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure()
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Action
            Func<Task> task = async () => await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddAsync(dimensionStructure)
               .ConfigureAwait(false);

            // Assert
            task.Should().Throw<Exception>();
        }

        public AddAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}