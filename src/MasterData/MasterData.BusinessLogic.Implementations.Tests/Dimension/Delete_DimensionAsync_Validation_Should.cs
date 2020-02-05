namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Delete_DimensionAsync_Validation_Should : TestBase
    {
        public Delete_DimensionAsync_Validation_Should() : base(TestInfo)
        {
        }

        protected const string TestInfo = nameof(Delete_DimensionAsync_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteDimensionAsync(dimension).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteDimensionAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}