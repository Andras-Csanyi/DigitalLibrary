namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Validators.TestData;

    using Xunit;

    public class Update_DimensionStructureAsync_Should : TestBase
    {
        private const string TestInfo = nameof(Update_DimensionStructureAsync_Should);

        public Update_DimensionStructureAsync_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task Update()
        {
            // Arrange
            string updateName = "update name";
            string updateDesc = "update desc";
            int updateIsActive = 0;

            DimensionStructure orig = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };
            DimensionStructure origResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                orig).ConfigureAwait(false);

            origResult.Name = updateName;
            origResult.Desc = updateDesc;
            origResult.IsActive = updateIsActive;

            // Act
            DimensionStructure updatedResult = await masterDataBusinessLogic.UpdateDimensionStructureAsync(
                origResult).ConfigureAwait(false);

            // Assert
            updatedResult.Id.Should().Be(origResult.Id);
            updatedResult.Name.Should().Be(updateName);
            updatedResult.Desc.Should().Be(updateDesc);
            updatedResult.IsActive.Should().Be(updateIsActive);
        }
    }
}