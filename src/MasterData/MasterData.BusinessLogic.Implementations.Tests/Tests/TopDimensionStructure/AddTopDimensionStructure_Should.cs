namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.TopDimensionStructure
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AddTopDimensionStructure_Should : TestBase
    {
        public AddTopDimensionStructure_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(AddTopDimensionStructure_Should);

        [Fact]
        public async Task AddNewDimensionStructure()
        {
            // Arrange
            DomainModel.DomainModel.Dimension dimension = new DomainModel.DomainModel.Dimension
            {
                Name = "name",
                Description = "desc",
                IsActive = 1
            };
            DomainModel.DomainModel.Dimension dimensionResult = await masterDataBusinessLogic.AddDimensionAsync(
                dimension).ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure dimensionStructure =
                new DomainModel.DomainModel.DimensionStructure
                {
                    Name = "name",
                    Desc = "desc",
                    IsActive = 1,
                    ParentDimensionStructureId = 0,
                    DimensionId = dimensionResult.Id
                };

            // Act
            DomainModel.DomainModel.DimensionStructure result = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(
                    dimensionStructure).ConfigureAwait(false);

            // Arrange
            result.Should().NotBeNull();
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(dimensionStructure.Name);
            result.Desc.Should().Be(dimensionStructure.Desc);
            result.IsActive.Should().Be(dimensionStructure.IsActive);
            result.ParentDimensionStructureId.Should().Be(dimensionStructure.ParentDimensionStructureId);
        }
    }
}