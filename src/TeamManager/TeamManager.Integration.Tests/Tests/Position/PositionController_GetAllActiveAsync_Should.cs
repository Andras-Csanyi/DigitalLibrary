namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Position
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

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Position")]
    public class PositionController_GetAllActiveAsync_Should : TestBase<Position>
    {
        public PositionController_GetAllActiveAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, Position> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Return_All_ActiveItems()
        {
            // Arrange

            // Act
            List<Position> result = await TeamManagerWebApiClient.PositionApiWebClient
                .GetAllActiveAsync()
                .ConfigureAwait(false);

            // Assert
            result.Count.Should().Be((int) TeamManagerSeed.PositionActiveAmount);
        }
    }
}