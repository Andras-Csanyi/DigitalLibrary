namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.PeopleEventLog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    public class PeopleEventLog_DeleteAsync_Should : TestBase<PeopleEventLog>
    {
        public static IEnumerable<object[]> CreateNewItem = new List<object[]>
        {
            new object[] { 2 },
            new object[] { 2 },
            new object[] { 2 },
            new object[] { 2 },
            new object[] { 2 },
        };

        public PeopleEventLog_DeleteAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, PeopleEventLog> host,
                                                 ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PeopleEventLogApiWebClientDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleEventLogApiWebClientArgumentNullException>();
        }

        public async Task Throw_PeopleEventLogApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            PeopleEventLog p = new PeopleEventLog
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.DeleteAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        [MemberData(nameof(CreateNewItem))]
        public async Task Delete_An_Item(long id)
        {
            // Arrange
            PeopleEventLog p = new PeopleEventLog
            {
                Id = id
            };

            // Act
            await TeamManagerWebApiClient.PeopleEventLogApiWebClient.DeleteAsync(p).ConfigureAwait(false);

            // Assert
            List<PeopleEventLog> res = await TeamManagerWebApiClient.PeopleEventLogApiWebClient
                .GetAllAsync()
                .ConfigureAwait(false);
            PeopleEventLog r = res.FirstOrDefault(k => k.Id == p.Id);
            r.Should().BeNull();
        }
    }
}