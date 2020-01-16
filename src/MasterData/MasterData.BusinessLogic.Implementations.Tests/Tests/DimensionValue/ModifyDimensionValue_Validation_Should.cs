using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions;
using DigitalLibrary.MasterData.Validators.TestData.TestData;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionValue
{
    [ExcludeFromCodeCoverage]
    public class ModifyDimensionValue_Validation_Should : TestBase
    {
        public ModifyDimensionValue_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(ModifyDimensionValue_Validation_Should);

        [Theory]
        [MemberData(
            nameof(MasterData_DimensionValue_TestData.DimensionValue_Modify_TestData),
            MemberType = typeof(MasterData_DimensionValue_TestData))]
        public async Task ThrowException_WhenInputIsNull(
            long id,
            DomainModel.DomainModel.DimensionValue oldDimensionValue,
            DomainModel.DomainModel.DimensionValue newDimensionValue)
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
                .WithInnerExceptionExactly<MasterDataBusinessLogicArgumentNullException>();
        }

        [Fact]
        public async Task ThrowException_WhenOldDimensionValue_HasZeroId()
        {
            // Arrange
            DomainModel.DomainModel.DimensionValue old = new DomainModel.DomainModel.DimensionValue();
            DomainModel.DomainModel.DimensionValue nw = new DomainModel.DomainModel.DimensionValue();

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