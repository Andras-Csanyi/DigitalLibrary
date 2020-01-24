namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Validators.TestData;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ModifyDimension_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(ModifyDimension_Validation_Should);

        public ModifyDimension_Validation_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputsAreNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.ModifyDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Name = name,
                Description = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.ModifyDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicModifyDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }
    }
}