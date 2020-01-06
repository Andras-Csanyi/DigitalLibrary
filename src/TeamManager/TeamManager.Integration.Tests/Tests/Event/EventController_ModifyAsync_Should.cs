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
    public class EventController_ModifyAsync_Should : TestBase<Event>
    {
        public static IEnumerable<object[]> ThrowEventApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { 1, null, 1 },
                new object[] { 1, string.Empty, 1 },
                new object[] { 1, " ", 1 },

                new object[] { 1, "asd", 2 },
            };

        public EventController_ModifyAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Event> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_EventApiWebClientModifyAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.ModifyAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<EventApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowEventApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_EventApiWebClientModifyAsyncOperationException_WhenInputIsInvalid(
            int id,
            string name,
            int isActive)
        {
            // Arrange
            Event modif = new Event
            {
                Id = id,
                Name = name,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.EventApiWebClient.ModifyAsync(modif).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<EventApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }
    }
}