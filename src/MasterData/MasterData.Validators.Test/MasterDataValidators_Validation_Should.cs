// <copyright file="MasterDataValidators_Validation_Should.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.MasterData.Validators.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA2211", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1806", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public class MasterDataValidators_Validation_Should
    {
        public static IEnumerable<object[]> ValidatorCtorInput = new List<object[]>
        {
            new object[]
            {
                null,
                null,
                null,
                null,
                null,
                null
            },
            new object[]
            {
                null,
                new MasterDataDimensionValueValidator(),
                new SourceFormatValidator(),
                new DimensionStructureValidator(),
                new DimensionStructureDimensionStructureValidator(),
                new DimensionStructureQueryObjectValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                null,
                new SourceFormatValidator(),
                new DimensionStructureValidator(),
                new DimensionStructureDimensionStructureValidator(),
                new DimensionStructureQueryObjectValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                null,
                new DimensionStructureValidator(),
                new DimensionStructureDimensionStructureValidator(),
                new DimensionStructureQueryObjectValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                new SourceFormatValidator(),
                null,
                new DimensionStructureDimensionStructureValidator(),
                new DimensionStructureQueryObjectValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                new SourceFormatValidator(),
                new DimensionStructureValidator(),
                null,
                new DimensionStructureQueryObjectValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                new SourceFormatValidator(),
                new DimensionStructureValidator(),
                new DimensionStructureDimensionStructureValidator(),
                null,
            },
        };

        [Theory]
        [MemberData(nameof(ValidatorCtorInput))]
        public void ThrowException_WhenAnyCtorInput_IsNull(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator masterDataDimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator,
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator,
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator)
        {
            // Arrange

            // Act
            Action action = () =>
            {
                new MasterDataValidators(
                    dimensionValidator,
                    masterDataDimensionValueValidator,
                    sourceFormatValidator,
                    dimensionStructureValidator,
                    dimensionStructureDimensionStructureValidator,
                    dimensionStructureQueryObjectValidator
                );
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}