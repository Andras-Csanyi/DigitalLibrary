// <copyright file="Get_DimensionStructure_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class Get_DimensionStructure_Should : TestBase
    {
        public Get_DimensionStructure_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Get_DimensionStructure_Should);

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