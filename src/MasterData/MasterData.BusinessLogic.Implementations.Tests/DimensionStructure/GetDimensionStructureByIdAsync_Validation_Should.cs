namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class GetDimensionStructureByIdAsync_Validation_Should : TestBase
    {
        public GetDimensionStructureByIdAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(GetDimensionStructureByIdAsync_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.GetDimensionStructureByIdAsync(null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException>();
        }
    }
}