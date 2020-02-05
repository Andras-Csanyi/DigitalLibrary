namespace DigitalLibrary.ControlPanel.WebApi.Client.Unit.Tests.Module
{
    using System;
    using System.Threading.Tasks;

    using Client.Menu.Exceptions;

    using FluentAssertions;

    using Xunit;

    public class FindAsync_Should : TestBase
    {
        [Fact]
        [Trait("Category", "Unit")]
        public async Task Throw_ArgumentNullException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await ControlPanelWebApiClient.FindModuleAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<ControlPanelWebApiClientFindModuleAsyncOperationException>();
        }
    }
}