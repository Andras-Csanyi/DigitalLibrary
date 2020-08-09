namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "UnusedVariable")]
    public class Add_SourceFormat_Should : TestBase
    {
        public Add_SourceFormat_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_SourceFormat_Should);

        [Fact]
        public async Task Add_TheItem()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            // Act
            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(sourceFormat.Name);
            result.Desc.Should().Be(sourceFormat.Desc);
            result.IsActive.Should().Be(sourceFormat.IsActive);
        }

        [Fact]
        public async Task ThrowExpection_WhenNameUniqueConstraintIsViolated()
        {
            // Arrange
            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                sourceFormat).ConfigureAwait(false);

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddSourceFormatAsyncOperationException>();
        }
    }
}