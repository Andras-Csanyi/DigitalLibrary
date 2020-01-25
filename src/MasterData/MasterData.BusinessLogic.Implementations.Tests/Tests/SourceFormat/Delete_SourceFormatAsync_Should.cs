namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Delete_SourceFormatAsync_Should : TestBase
    {
        public Delete_SourceFormatAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Delete_SourceFormatAsync_Should);

        [Fact]
        public async Task Delete()
        {
            // Arrange
            SourceFormat first = new SourceFormat
            {
                Name = "first",
                Desc = "first",
                IsActive = 1,
            };
            SourceFormat firstResult = await masterDataBusinessLogic.AddSourceFormatAsync(first)
               .ConfigureAwait(false);

            SourceFormat second = new SourceFormat
            {
                Name = "second",
                Desc = "second",
                IsActive = 1,
            };
            SourceFormat secondResult = await masterDataBusinessLogic.AddSourceFormatAsync(second)
               .ConfigureAwait(false);

            // Act
            await masterDataBusinessLogic.DeleteSourceFormatAsync(secondResult).ConfigureAwait(false);

            // Assert
            List<SourceFormat> result = await masterDataBusinessLogic.GetSourceFormatsAsync()
               .ConfigureAwait(false);

            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task ThrowException_WhenEntityDoesntExist()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat { Id = 100 };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should()
               .ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchSourceFormatEntityException>();
        }
    }
}