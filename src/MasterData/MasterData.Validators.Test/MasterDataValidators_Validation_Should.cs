namespace DigitalLibrary.MasterData.Validators.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class MasterDataValidators_Validation_Should
    {
        public static IEnumerable<object[]> ValidatorCtorInput = new List<object[]>
        {
            new object[]
            {
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
            },
            new object[]
            {
                new DimensionValidator(),
                null,
                new SourceFormatValidator(),
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                null,
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new DimensionValidator(),
                new MasterDataDimensionValueValidator(),
                new SourceFormatValidator(),
                null
            }
        };

        [Theory]
        [MemberData(nameof(ValidatorCtorInput))]
        public void ThrowException_WhenAnyCtorInput_IsNull(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator masterDataDimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                new MasterDataValidators(
                    dimensionValidator,
                    masterDataDimensionValueValidator,
                    sourceFormatValidator,
                    dimensionStructureValidator
                );
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}