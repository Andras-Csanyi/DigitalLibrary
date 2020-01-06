namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Event
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

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Event")]
    public class EventController_GetAllAsync_Should : TestBase<Event>
    {
        public EventController_GetAllAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Event> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Return_All_Item()
        {
            // Arrange

            // Act
            List<Event> result = await TeamManagerWebApiClient.EventApiWebClient.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be((int) (TeamManagerSeed.EventsActiveAmount + TeamManagerSeed.EventsInActiveAmount));
        }
    }
}