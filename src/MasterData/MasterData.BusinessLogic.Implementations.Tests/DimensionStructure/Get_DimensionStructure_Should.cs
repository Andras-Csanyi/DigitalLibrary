namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Get_DimensionStructure_Should : TestBase
    {
        private const string TestInfo = nameof(Get_DimensionStructure_Should);

        public Get_DimensionStructure_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task Delete_AnItem()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1
            };
            DimensionStructure dimensionStructureResult = await masterDataBusinessLogic.AddDimensionStructureAsync(
                    dimensionStructure)
               .ConfigureAwait(false);

            DimensionStructure dimensionStructure2 = new DimensionStructure
            {
                Name = "name2",
                Desc = "desc2",
                IsActive = 0
            };
            DimensionStructure dimensionStructure2Result = await masterDataBusinessLogic.AddDimensionStructureAsync(
                    dimensionStructure2)
               .ConfigureAwait(false);

            // Act
            List<DimensionStructure> result = await masterDataBusinessLogic.GetDimensionStructuresAsync()
               .ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
            result.Where(p => p.Name == dimensionStructure.Name).ToList().Count.Should().Be(1);
            result.Where(p => p.Name == dimensionStructure2.Name).ToList().Count.Should().Be(1);
        }
    }
}