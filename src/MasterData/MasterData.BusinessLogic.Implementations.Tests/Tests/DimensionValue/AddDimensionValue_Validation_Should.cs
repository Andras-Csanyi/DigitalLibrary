namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AddDimensionValue_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(AddDimensionValue_Validation_Should);

        public AddDimensionValue_Validation_Should() : base(TestInfo)
        {
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public async Task Throw_MasterDataBusinessLogicAddDimensionValueOperationException_WhenInputIsNull(
            long dimensionId,
            long dimensionValueId)
        {
            // Arrange
            DimensionValue dimensionValue = new DimensionValue
            {
                Id = dimensionValueId
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.AddDimensionValueAsync(dimensionValue, dimensionId)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionValueAsyncOperationException>();
        }
    }
}