namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.PeopleEventLog
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.PeopleEventLog.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.PeopleEventLog")]
    public class PeopleEventLog_AddAsync_Should : TestBase<PeopleEventLog>
    {
        public static IEnumerable<object[]> ThrowPeopleEventLogApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid
            = new List<object[]>
            {
                new object[] { null, 1, 1, 1 },
                new object[] { string.Empty, 1, 1, 1 },
                new object[] { " ", 1, 1, 1 },

                new object[] { "asd", 2, 1, 1 },

                new object[] { "asd", 1, 0, 1 },

                new object[] { "asd", 1, 1, 0 },
            };

        public PeopleEventLog_AddAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, PeopleEventLog> host,
                                              ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PeopleEventLogApiWebClientAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.AddAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleEventLogApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowPeopleEventLogApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_PeopleEventLogApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
            string details,
            int isActive,
            long eventId,
            long peopleId)
        {
            // Arrange
            PeopleEventLog p = new PeopleEventLog
            {
                Details = details,
                IsActive = isActive,
                EventId = eventId,
                PeopleId = peopleId
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.AddAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Create_New_Item()
        {
            // Arrange
            PeopleEventLog p = new PeopleEventLog
            {
                Details = "asd",
                IsActive = 1,
                EventId = 1,
                PeopleId = 1
            };

            // Act
            PeopleEventLog res = await TeamManagerWebApiClient.PeopleEventLogApiWebClient.AddAsync(p)
                .ConfigureAwait(false);

            // Assert
            res.Details.Should().Be(p.Details);
            res.IsActive.Should().Be(p.IsActive);
            res.EventId.Should().Be(p.EventId);
            res.PeopleId.Should().Be(p.PeopleId);
        }
    }
}