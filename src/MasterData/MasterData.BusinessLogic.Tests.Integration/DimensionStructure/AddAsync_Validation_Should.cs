using DimensionStructure_Create_Validation_TestData =
    MasterData.Tests.TestData.DimensionStructure_Create_Validation_TestData;

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
    public class AddAsync_Validation_Should : TestBase
    {
        [Theory]
        [ClassData(typeof(DimensionStructure_Create_Validation_TestData))]
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
            task.Should().Throw<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        public AddAsync_Validation_Should(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
    }
}