namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class UpdateDimensionStructureAsync_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(UpdateDimensionStructureAsync_Validation_Should);

        public UpdateDimensionStructureAsync_Validation_Should() : base(TestInfo)
        {
        }

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.UpdateDimensionStructureAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
                .WithInnerException<ArgumentNullException>();
        }

        public async Task ThrowException_WhenInputIsInvalid()
        {
        }
    }
}