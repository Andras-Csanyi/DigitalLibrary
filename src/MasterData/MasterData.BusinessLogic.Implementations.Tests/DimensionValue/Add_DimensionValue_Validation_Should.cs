// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    public class Add_DimensionValue_Validation_Should : TestBase
    {
        private const string TestInfo = nameof(Add_DimensionValue_Validation_Should);

        public Add_DimensionValue_Validation_Should() : base(TestInfo)
        {
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 100)]
        public void Throw_MasterDataBusinessLogicAddDimensionValueOperationException_WhenInputIsNull(
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