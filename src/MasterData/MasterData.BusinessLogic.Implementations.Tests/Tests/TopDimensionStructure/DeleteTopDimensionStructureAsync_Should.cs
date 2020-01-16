namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Tests.Tests.TopDimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentAssertions;

    using Xunit;

    public class DeleteTopDimensionStructureAsync_Should : TestBase
    {
        public DeleteTopDimensionStructureAsync_Should() : base(TestInfo)
        {
        }

        private const string TestInfo = nameof(DeleteTopDimensionStructureAsync_Should);

        [Fact]
        public async Task Delete()
        {
            // Arrange
            DimensionStructure first = new DimensionStructure
            {
                Name = "first",
                Desc = "first",
                IsActive = 1
            };
            DimensionStructure firstResult = await masterDataBusinessLogic.AddTopDimensionStructureAsync(first)
                .ConfigureAwait(false);

            DimensionStructure second = new DimensionStructure
            {
                Name = "second",
                Desc = "second",
                IsActive = 1
            };
            DimensionStructure secondResult = await masterDataBusinessLogic.AddTopDimensionStructureAsync(second)
                .ConfigureAwait(false);

            // Act
            await masterDataBusinessLogic.DeleteDimensionStructureAsync(secondResult).ConfigureAwait(false);

            // Assert
            // action.Should().NotThrow();
            List<DimensionStructure> result = await masterDataBusinessLogic.GetTopDimensionStructuresAsync()
                .ConfigureAwait(false);

            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task ThrowException_WhenEntityDoesntExist()
        {
            // Arrange
            DimensionStructure dimensionStructure = new DimensionStructure { Id = 100 };

            // Act
            Func<Task> action = async () =>
            {
                await masterDataBusinessLogic.DeleteDimensionStructureAsync(dimensionStructure)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException>()
                .WithInnerException<MasterDataBusinessLogicNoSuchDimensionStructureEntity>();
        }
    }
}