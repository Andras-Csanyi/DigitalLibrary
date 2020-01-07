namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class GetValuesOfADimensionAsync_Validation_Should : TestBase
    {
        public GetValuesOfADimensionAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(GetValuesOfADimensionAsync_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.GetValuesOfADimensionAsync(0)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicGetDimensionValueAsyncOperationException>()
                .WithInnerExceptionExactly<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}