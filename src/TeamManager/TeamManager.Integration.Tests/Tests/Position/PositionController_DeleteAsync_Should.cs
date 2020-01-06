namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Position
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.Position.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Position")]
    public class PositionController_DeleteAsync_Should : TestBase<Position>
    {
        public PositionController_DeleteAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Position> host,
                                                     ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PositionApiWebClientDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PositionApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PositionApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<PositionApiWebClientArgumentNullException>();
        }

        public async Task Throw_PositionApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            Position p = new Position
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PositionApiWebClient.DeleteAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PositionApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Delete_An_Item()
        {
            // Arrange
            Position p = new Position
            {
                Id = 2
            };

            List<Position> all = await TeamManagerWebApiClient.PositionApiWebClient.GetAllAsync().ConfigureAwait(false);

            // Act
            await TeamManagerWebApiClient.PositionApiWebClient.DeleteAsync(p).ConfigureAwait(false);

            // Assert
            List<Position> resultAfterDelete = await TeamManagerWebApiClient.PositionApiWebClient
                .GetAllAsync()
                .ConfigureAwait(false);

            resultAfterDelete.Count.Should().Be(all.Count - 1);
        }
    }
}