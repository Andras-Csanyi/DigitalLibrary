namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Title
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

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Title")]
    public class TitleController_GetAllActiveAsync_Should : TestBase<Title>
    {
        public TitleController_GetAllActiveAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Title> host,
                                                        ITestOutputHelper testOutputHelper) : base(host,
            testOutputHelper)
        {
        }

        public async Task Get_AllActiveItem()
        {
            // Arrange

            // Act
            List<Title> res = await TeamManagerWebApiClient.TitleApiWebClient.GetAllActiveAsync()
                .ConfigureAwait(false);

            // Assert
            res.Count.Should().Be((int) TeamManagerSeed.TitleActiveAmount);
        }
    }
}