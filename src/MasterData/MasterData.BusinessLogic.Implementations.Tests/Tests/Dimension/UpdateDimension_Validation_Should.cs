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
    public class UpdateDimension_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(UpdateDimension_Validation_Should);

        public UpdateDimension_Validation_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputsAreNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(MasterData_Dimension_TestData.UpdateDimensionAsync_Validation),
            MemberType = typeof(MasterData_Dimension_TestData))]
        public async Task ThrowException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            int isActive)
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }
    }
}