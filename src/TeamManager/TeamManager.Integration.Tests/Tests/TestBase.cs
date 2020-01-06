namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests
{
    using System;
    using System.Net.Http;

    using Factories;

    using Microsoft.AspNetCore.Mvc.Testing;

    using WebApi.Client.Client;
    using WebApi.Client.Client.Company;
    using WebApi.Client.Client.Event;
    using WebApi.Client.Client.People;
    using WebApi.Client.Client.PeopleEventLog;
    using WebApi.Client.Client.Position;
    using WebApi.Client.Client.Title;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    public class TestBase<TTestedEntity> : IClassFixture<DiLibTeamManagerWebApplicationFactory<Startup, TTestedEntity>>
        where TTestedEntity : class
    {
        protected readonly WebApplicationFactory<Startup> _host;

        protected readonly TeamManagerWebApiClient TeamManagerWebApiClient;

        protected readonly ITestOutputHelper TestOutputHelper;

        public TestBase(DiLibTeamManagerWebApplicationFactory<Startup, TTestedEntity> host,
                        ITestOutputHelper testOutputHelper)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            TestOutputHelper = testOutputHelper;

            HttpClient httpClient = _host.CreateClient();

            CompanyApiWebClient companyApiWebClient = new CompanyApiWebClient(httpClient);
            EventApiWebClient eventApiWebClient = new EventApiWebClient(httpClient);
            PeopleApiWebClient peopleApiWebClient = new PeopleApiWebClient(httpClient);
            PeopleEventLogApiWebClient peopleEventLogWebApiClient = new PeopleEventLogApiWebClient(httpClient);
            PositionApiWebClient positionApiWebClient = new PositionApiWebClient(httpClient);
            TitleApiWebClient titleApiWebClient = new TitleApiWebClient(httpClient);

            TeamManagerWebApiClient = new TeamManagerWebApiClient(
                companyApiWebClient,
                eventApiWebClient,
                peopleApiWebClient,
                peopleEventLogWebApiClient,
                positionApiWebClient,
                titleApiWebClient);
        }
    }
}