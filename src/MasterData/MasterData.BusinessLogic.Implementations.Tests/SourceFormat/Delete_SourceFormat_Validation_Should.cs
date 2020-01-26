namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using FluentValidation;

    using Utils.Guards;

    using Xunit;

    public class Delete_SourceFormat_Validation_Should : TestBase
    {
        public Delete_SourceFormat_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Delete_SourceFormat_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
               .WithInnerException<ValidationException>();
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteSourceFormatAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
               .WithInnerException<GuardException>();
        }
    }
}