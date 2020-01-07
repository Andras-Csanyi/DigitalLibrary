namespace MasterData.Validators.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.IaC.MasterData.Validators.Validators;

    using FluentAssertions;

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
            },
            new object[]
            {
                null,
                new MasterDataDimensionValueValidator(),
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new MasterDataDimensionValidator(),
                null,
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new MasterDataDimensionValidator(),
                new MasterDataDimensionValueValidator(),
                null
            }
        };

        [Theory]
        [MemberData(nameof(ValidatorCtorInput))]
        public void ThrowException_WhenAnyCtorInput_IsNull(
            MasterDataDimensionValidator masterDataDimensionValidator,
            MasterDataDimensionValueValidator masterDataDimensionValueValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                new MasterDataValidators(
                    masterDataDimensionValidator,
                    masterDataDimensionValueValidator,
                    dimensionStructureValidator
                );
            };

            // Assert
            action.Should().ThrowExactly<MasterDataValidatorFacadeArgumentNullException>();
        }
    }
}