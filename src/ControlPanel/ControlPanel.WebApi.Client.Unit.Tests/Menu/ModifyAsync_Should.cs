namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests.Menu
{
    using System;
    using System.Threading.Tasks;

    using Client.Menu.Exceptions;

    using FluentAssertions;

    using Xunit;

    public class ModifyAsync_Should : TestBase
    {
        [Fact]
        [Trait("Category", "Unit")]
        public async Task Throw_ArgumentNullException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await ControlPanelWebApiClient.ModifyMenuAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<ControlPanelWebApiClientModifyMenuAsyncOperationException>();
        }
    }
}