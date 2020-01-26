namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Utils.Guards;

    using Validators.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Update_DimensionValue_Validation_Should : TestBase
    {
        public Update_DimensionValue_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Update_DimensionValue_Validation_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_DimensionValue_TestData.DimensionValue_Modify_TestData),
            MemberType = typeof(MasterData_DimensionValue_TestData))]
        public async Task ThrowException_WhenInputIsNull(
            long id,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionValue)
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionValueAsync(
                    id,
                    oldDimensionValue,
                    newDimensionValue).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
               .WithInnerExceptionExactly<GuardException>();
        }

        [Fact]
        public async Task ThrowException_WhenOldDimensionValue_HasZeroId()
        {
            // Arrange
            DimensionValue old = new DimensionValue();
            DimensionValue nw = new DimensionValue();

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionValueAsync(
                    100,
                    old,
                    nw).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionValueAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }
    }
}