namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.PeopleEventLog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using Utils;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.PeopleEventLog")]
    public class PeopleEventLog_GetAllActiveAsync_Should : TestBase<PeopleEventLog>
    {
        public PeopleEventLog_GetAllActiveAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, PeopleEventLog> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Return_With_Items()
        {
            // Arrange

            // Act
            List<PeopleEventLog> res = await TeamManagerWebApiClient.PeopleEventLogApiWebClient
                .GetAllActiveAsync().ConfigureAwait(false);

            // Assert
            res.Count.Should().Be((int) (TeamManagerSeed.PeopleEventLogsActiveAmount));
        }
    }
}