namespace WebUI.Test.SourceFormatBuilderService
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Ui.WebUi.Services;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class RemoveItemFromTreeAsync_Should : TestBase
    {
        [Fact]
        public async Task RemoveRootDimensionStructure()
        {
            // Arrange
            ISourceFormatBuilderService builderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object);

            // Act
            Func<Task> action = async () =>
            {
                await builderService.DeleteDocumentStructureFromTreeAsync(0).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public async Task RemoveItem_WhenOnlyASingleItemIsOnTheFirstLevel()
        {
        }

        [Fact]
        public async Task RemoveItem_WhenMultipleItemsOnTheFirstLevel()
        {
        }

        [Fact]
        public async Task RemoveItemWithItsChildren_WhenMultipleItemsOnTheFirstLevel()
        {
        }

        [Fact]
        public async Task RemoveItem_WhenSingleItemOnTheSecondLevel()
        {
        }

        [Fact]
        public async Task RemoveItemWithItsChildren_WhenMultlpleElemsAreOnTheSecondLevel()
        {
        }

        [Fact]
        public async Task ReturnsWithTheTreeUnchanged_WhenThereIsNoItemToBeRemoved()
        {
        }
    }
}