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
    public class Add_Should : TestBase
    {
        public Add_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(Add_Should);

        [Fact]
        public async Task ThrowExpection_WhenNameUniqueConstraintIsViolated()
        {
            // Arrange
            SourceFormat dimensionStructure = new SourceFormat
            {
                Name = "name",
                Desc = "desc",
                IsActive = 1,
            };

            SourceFormat result = await masterDataBusinessLogic.AddSourceFormatAsync(
                dimensionStructure).ConfigureAwait(false);


            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddSourceFormatAsync(dimensionStructure).ConfigureAwait(false);
            };

            // Arrange
            action.Should().ThrowExactly<MasterDataBusinessLogicAddSourceFormatAsyncOperationException>();
        }
    }
}