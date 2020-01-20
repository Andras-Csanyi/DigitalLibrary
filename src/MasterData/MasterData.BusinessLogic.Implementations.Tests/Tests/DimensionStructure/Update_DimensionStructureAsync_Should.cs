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

        [Theory]
        [MemberData(nameof(MasterData_DimensionStructure_TestData.ModifyDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Update(
            string updateName,
            string updateDesc,
            int updateIsActive)
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            Dimension dimension1Result = await masterDataBusinessLogic.AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "name2",
                Description = "desc2",
                IsActive = 1
            };
            Dimension dimension2Result = await masterDataBusinessLogic.AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };
            SourceFormat sourceFormatResult = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat).ConfigureAwait(false);

            DimensionStructure orig = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
                DimensionId = dimension1.Id
            };
            DimensionStructure origResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                orig).ConfigureAwait(false);

            SourceFormat sourceFormat2 = new SourceFormat
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 1,
            };
            SourceFormat sourceFormat2Result = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat2).ConfigureAwait(false);

            origResult.Name = updateName;
            origResult.Desc = updateDesc;
            origResult.IsActive = updateIsActive;
            origResult.DimensionId = dimension2.Id;

            // Act
            DimensionStructure updatedResult = await masterDataBusinessLogic.UpdateDimensionStructureAsync(
                orig).ConfigureAwait(false);

            // Assert
            updatedResult.Id.Should().Be(origResult.Id);
            updatedResult.Name.Should().Be(updateName);
            updatedResult.Desc.Should().Be(updateDesc);
            updatedResult.IsActive.Should().Be(updateIsActive);
            updatedResult.DimensionId.Should().Be(dimension2Result.Id);
        }
    }
}