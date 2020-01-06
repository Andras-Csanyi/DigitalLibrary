namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests
{
    using System.Net.Http;

    using Client.Position;
    using Client.Title;

    public class TestBase
    {
        protected readonly Client.TeamManagerWebApiClient TeamManagerWebApiClient;

        public TestBase()
        {
            HttpClient httpClient = new HttpClient();
            Client.Company.CompanyApiWebClient companyApiWebClient = new Client.Company.CompanyApiWebClient(httpClient);
            Client.Event.EventApiWebClient eventApiWebClient = new Client.Event.EventApiWebClient(httpClient);
            Client.People.PeopleApiWebClient peopleApiWebClient = new Client.People.PeopleApiWebClient(httpClient);
            Client.PeopleEventLog.PeopleEventLogApiWebClient peopleEventLogWebApiClient = new Client.PeopleEventLog
                .PeopleEventLogApiWebClient(httpClient);
            PositionApiWebClient positionApiWebClient = new PositionApiWebClient(httpClient);
            TitleApiWebClient titleApiWebClient = new TitleApiWebClient(httpClient);

            TeamManagerWebApiClient = new Client.TeamManagerWebApiClient(
                companyApiWebClient,
                eventApiWebClient,
                peopleApiWebClient,
                peopleEventLogWebApiClient,
                positionApiWebClient,
                titleApiWebClient);
        }
    }
}