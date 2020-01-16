namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

    public class DeleteDimensionStructureAsync_Validation_Should : TestBase
    {
        public DeleteDimensionStructureAsync_Validation_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(DeleteDimensionStructureAsync_Validation_Should);

        [Fact]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteDimensionStructureAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
        }
    }
}