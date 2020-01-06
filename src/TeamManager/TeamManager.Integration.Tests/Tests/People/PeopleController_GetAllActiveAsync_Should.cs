namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.People
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

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.People")]
    public class PeopleController_GetAllActiveAsync_Should : TestBase<People>
    {
        public PeopleController_GetAllActiveAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, People> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task ReturnAllActive()
        {
            // Arrange

            // Act
            List<People> list =
                await TeamManagerWebApiClient.PeopleApiWebClient.GetAllActiveAsync().ConfigureAwait(false);

            // Assert
            list.Count.Should().Be((int) TeamManagerSeed.PeopleActiveAmount);
        }
    }
}