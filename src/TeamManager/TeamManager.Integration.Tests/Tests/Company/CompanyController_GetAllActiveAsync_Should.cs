namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Company
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

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Company")]
    public class CompanyController_GetAllActiveAsync_Should : TestBase<Company>
    {
        public CompanyController_GetAllActiveAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Company> host,
                                                          ITestOutputHelper testOutputHelper) : base(host,
            testOutputHelper)
        {
        }

        public async Task Return_WithAllActiveItems()
        {
            // Arrange

            // Act
            List<Company> result = await TeamManagerWebApiClient.CompanyApiWebClient.GetAllActiveAsync()
                .ConfigureAwait(false);

            // Assert
            result.Count.Should().Be((int) TeamManagerSeed.CompanyActiveAmount);
        }
    }
}