using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Tests.TopDimensionStructure
{
    using Exceptions;

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
            DomainModel.DomainModel.DimensionStructure first = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "first",
                Desc = "first",
                IsActive = 1
            };
            DomainModel.DomainModel.DimensionStructure firstResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(first)
               .ConfigureAwait(false);

            DomainModel.DomainModel.DimensionStructure second = new DomainModel.DomainModel.DimensionStructure
            {
                Name = "second",
                Desc = "second",
                IsActive = 1
            };
            DomainModel.DomainModel.DimensionStructure secondResult = await masterDataBusinessLogic
               .AddTopDimensionStructureAsync(second)
               .ConfigureAwait(false);

            // Act
            await masterDataBusinessLogic.DeleteDimensionStructureAsync(secondResult).ConfigureAwait(false);

            // Assert
            // action.Should().NotThrow();
            List<DomainModel.DomainModel.DimensionStructure> result = await masterDataBusinessLogic
               .GetTopDimensionStructuresAsync()
               .ConfigureAwait(false);

            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task ThrowException_WhenEntityDoesntExist()
        {
            // Arrange
            DomainModel.DomainModel.DimensionStructure dimensionStructure =
                new DomainModel.DomainModel.DimensionStructure { Id = 100 };

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