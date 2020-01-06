namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Event
{
    using System;
    using System.Collections.Generic;
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
    public class EventController_AddAsync_Should : TestBase<Event>
    {
        public static IEnumerable<object[]> ThrowEventApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { null, 1 },
                new object[] { string.Empty, 1 },
                new object[] { " ", 1 },

                new object[] { " ", 2 },
            };

        public EventController_AddAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Event> host,
                                               ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_EventApiWebClientAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.AddAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<EventApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowEventApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_EventApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
            string name,
            int isActive)
        {
            // Arrange
            Event e = new Event
            {
                Name = name,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.AddAsync(e).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Add_An_Item()
        {
            // Arrange
            Event e = new Event
            {
                Name = "new one",
                IsActive = 1
            };

            // Act
            Event res = await TeamManagerWebApiClient.EventApiWebClient.AddAsync(e).ConfigureAwait(false);

            // Assert
            res.Id.Should().NotBe(0);
            res.Name.Should().Be(e.Name);
            res.IsActive.Should().Be(e.IsActive);
        }
    }
}