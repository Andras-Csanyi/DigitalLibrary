namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    using Exceptions;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DeleteDimensionAsync_Should : TestBase
    {
        public DeleteDimensionAsync_Should() : base(TestInfo)
        {
        }

        protected const string TestInfo = nameof(DeleteDimensionAsync_Should);

        [Fact]
        public async Task Delete_TheItem()
        {
            // Arrange
            Dimension dimension1 = new Dimension
            {
                Name = "name1",
                Description = "desc1",
                IsActive = 1
            };
            Dimension dimension1Result = await masterDataBusinessLogic.AddDimensionAsync(dimension1)
               .ConfigureAwait(false);

            Dimension dimension2 = new Dimension
            {
                Name = "name2",
                Description = "desc2",
                IsActive = 1
            };
            Dimension dimension2Result = await masterDataBusinessLogic.AddDimensionAsync(dimension2)
               .ConfigureAwait(false);

            // Act
            await masterDataBusinessLogic.DeleteDimensionAsync(dimension2Result).ConfigureAwait(false);

            // Assert
            List<Dimension> result = await masterDataBusinessLogic.GetDimensionsAsync().ConfigureAwait(false);
            result.Where(p => p.Id == dimension1Result.Id).ToList().Count.Should().Be(1);
            result.Where(p => p.Id == dimension2Result.Id).ToList().Count.Should().Be(0);
        }

        [Fact]
        public async Task ThrowException_WhenThereIsNoEntity()
        {
            // Arrange
            Dimension dimension = new Dimension
            {
                Id = 100,
            };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteDimensionAsync(dimension)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
               .WithInnerException<MasterDataBusinessLogicNoSuchDimensionEntity>();
        }
    }
}