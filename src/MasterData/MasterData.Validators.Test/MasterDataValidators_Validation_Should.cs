using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.MasterData.Validators.Test
{
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
                new TopDimensionStructureValidator(),
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new MasterDataDimensionValidator(),
                null,
                new TopDimensionStructureValidator(),
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new MasterDataDimensionValidator(),
                new MasterDataDimensionValueValidator(),
                null,
                new DimensionStructureValidator(),
            },
            new object[]
            {
                new MasterDataDimensionValidator(),
                new MasterDataDimensionValueValidator(),
                new TopDimensionStructureValidator(),
                null
            }
        };

        [Theory]
        [MemberData(nameof(ValidatorCtorInput))]
        public void ThrowException_WhenAnyCtorInput_IsNull(
            MasterDataDimensionValidator masterDataDimensionValidator,
            MasterDataDimensionValueValidator masterDataDimensionValueValidator,
            TopDimensionStructureValidator topDimensionStructureValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                new MasterDataValidators(
                    masterDataDimensionValidator,
                    masterDataDimensionValueValidator,
                    topDimensionStructureValidator,
                    dimensionStructureValidator
                );
            };

            // Assert
            action.Should().ThrowExactly<MasterDataValidatorFacadeArgumentNullException>();
        }
    }
}