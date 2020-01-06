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
    public class PeopleController_GetAllAsync_Should : TestBase<People>
    {
        public PeopleController_GetAllAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, People> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task ReturnAll()
        {
            // Arrange

            // Act
            List<People> list = await TeamManagerWebApiClient.PeopleApiWebClient.GetAllAsync().ConfigureAwait(false);

            // Assert
            list.Count.Should().Be((int) (TeamManagerSeed.PeopleActiveAmount + TeamManagerSeed.PeopleInActiveAmount));
        }
    }
}