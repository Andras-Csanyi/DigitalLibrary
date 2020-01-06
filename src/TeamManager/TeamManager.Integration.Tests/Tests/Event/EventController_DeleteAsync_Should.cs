namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.Event.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Event")]
    public class EventController_DeleteAsync_Should : TestBase<Event>
    {
        public EventController_DeleteAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Event> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_EventApiWebClientDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<EventApiWebClientArgumentNullException>();
        }

        public async Task Throw_EventApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            Event e = new Event
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.DeleteAsync(e).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Delete_An_Item()
        {
            // Arrange
            Event orig = new Event
            {
                Name = "to be deleted",
                IsActive = 1
            };
            Event result = await TeamManagerWebApiClient.EventApiWebClient.AddAsync(orig).ConfigureAwait(false);

            List<Event> listAfterOrigAdded = await TeamManagerWebApiClient.EventApiWebClient
                .GetAllAsync().ConfigureAwait(false);

            // Act
            await TeamManagerWebApiClient.EventApiWebClient.DeleteAsync(result).ConfigureAwait(false);

            // Assert
            List<Event> listAfterDelete = await TeamManagerWebApiClient.EventApiWebClient.GetAllAsync()
                .ConfigureAwait(false);
            Event finding = listAfterDelete.FirstOrDefault(p => p.Id == result.Id);

            finding.Should().BeNull();
        }
    }
}