// <copyright file="DimensionStructure_Should.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1806", Justification = "Reviewed.")]
    public class DimensionStructure_Should
    {
        [Fact]
        public void Properties_ShouldNotBeChangedBySetterAndGetter()
        {
            // Arrange
            long id = 100;
            string name = "name";
            string desc = "desc";
            int isActive = 1;

            // Act
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Id = id,
                Name = name,
                Desc = desc,
                IsActive = isActive,
            };

            // Assert
            dimensionStructure.Id.Should().Be(id);
            dimensionStructure.Name.Should().Be(name);
            dimensionStructure.Desc.Should().Be(desc);
            dimensionStructure.IsActive.Should().Be(isActive);
        }
    }
}
