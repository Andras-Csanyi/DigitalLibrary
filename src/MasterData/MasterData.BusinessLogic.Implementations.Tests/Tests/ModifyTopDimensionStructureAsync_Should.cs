namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Validators.TestData.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ModifyTopDimensionStructureAsync_Should : TestBase
    {
        public ModifyTopDimensionStructureAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(ModifyTopDimensionStructureAsync_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_DimensionStructure_TestData.ModifyTopDimensionStructure_TestData),
            MemberType = typeof(MasterData_DimensionStructure_TestData))]
        public async Task Modify_TopDimensionStructure(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            DimensionStructure orig = new DimensionStructure
            {
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
                ParentDimensionStructureId = 0
            };

            DimensionStructure origRes = await masterDataBusinessLogic.AddTopDimensionStructureAsync(
                orig).ConfigureAwait(false);

            DimensionStructure mod = new DimensionStructure
            {
                Id = origRes.Id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Act
            DimensionStructure res = await masterDataBusinessLogic.UpdateTopDimensionStructureAsync(mod)
                .ConfigureAwait(false);

            // Assert
            res.Should().NotBeNull();
            res.Id.Should().Be(origRes.Id);
            res.Name.Should().Be(name);
            res.Desc.Should().Be(desc);
            res.IsActive.Should().Be(isActive);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoGivenTopDimensionStructure()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = 100,
                Name = "asdasd",
                Desc = "asdasd",
                IsActive = 1,
                ParentDimensionStructureId = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateTopDimensionStructureAsync(dimensionStructure)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateTopDimensionStructureAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicNoSuchTopDimensionStructureEntity>();
        }
    }
}