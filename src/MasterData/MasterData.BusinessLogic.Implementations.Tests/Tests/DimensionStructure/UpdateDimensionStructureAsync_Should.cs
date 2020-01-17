namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionStructure
{
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using FluentAssertions;

    using Validators.TestData.TestData;

    using Xunit;

    public class UpdateDimensionStructureAsync_Should : TestBase
    {
        private const string TestInfo = nameof(UpdateDimensionStructureAsync_Should);

        public UpdateDimensionStructureAsync_Should() : base(TestInfo)
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
            
            DimensionStructure top = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };
            DimensionStructure topResult = await masterDataBusinessLogic.AddTopDimensionStructureAsync(
                top).ConfigureAwait(false);
            
            DimensionStructure orig = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
                ParentDimensionStructureId = topResult.Id,
                DimensionId = dimension1.Id
            };
            DimensionStructure origResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                orig).ConfigureAwait(false);
            
            DimensionStructure orig2 = new DimensionStructure
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 1,
            };
            DimensionStructure orig2Result = await masterDataBusinessLogic.AddTopDimensionStructureAsync(
                orig2).ConfigureAwait(false);

            origResult.Name = updateName;
            origResult.Desc = updateDesc;
            origResult.IsActive = updateIsActive;
            origResult.ParentDimensionStructureId = orig2Result.Id;
            origResult.DimensionId = dimension2.Id;

            // Act
            DimensionStructure updatedResult = await masterDataBusinessLogic.UpdateDimensionStructureAsync(
                orig).ConfigureAwait(false);
            
            // Assert
            updatedResult.Id.Should().Be(origResult.Id);
            updatedResult.Name.Should().Be(updateName);
            updatedResult.Desc.Should().Be(updateDesc);
            updatedResult.IsActive.Should().Be(updateIsActive);
            updatedResult.ParentDimensionStructureId.Should().Be(orig2Result.Id);
            updatedResult.DimensionId.Should().Be(dimension2Result.Id);
        }
    }
}