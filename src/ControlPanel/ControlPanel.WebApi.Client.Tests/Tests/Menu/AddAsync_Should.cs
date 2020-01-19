using System;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Tests.Tests.Menu
{
    using Client.Menu.Exceptions;

    public class AddAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task Throw_ArgumentNullException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await ControlPanelWebApiClient
                   .AddMenuAsync(null).ConfigureAwait(false);
            };

            // Arrange
            action.Should().ThrowExactly<ControlPanelWebApiClientAddMenuAsyncOperationException>();
        }
    }
}