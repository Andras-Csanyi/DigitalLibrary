namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client
{
    using Company;

    using Event;

    using Exceptions;

    using People;

    using PeopleEventLog;

    using Position;

    using Title;

    public class TeamManagerWebApiClient : ITeamManagerWebApiClient
    {
        public TeamManagerWebApiClient(
            CompanyApiWebClient companyApiWebClient,
            EventApiWebClient eventApiWebClient,
            PeopleApiWebClient peopleApiWebClient,
            PeopleEventLogApiWebClient peopleEventLogApiWebClient,
            PositionApiWebClient positionApiWebClient,
            TitleApiWebClient titleApiWebClient)
        {
            CompanyApiWebClient = companyApiWebClient
                                  ?? throw new TeamManagerWebApiClientArgumentNullException(
                                      nameof(companyApiWebClient));
            EventApiWebClient = eventApiWebClient
                                ?? throw new TeamManagerWebApiClientArgumentNullException(nameof(eventApiWebClient));
            PeopleApiWebClient = peopleApiWebClient
                                 ?? throw new TeamManagerWebApiClientArgumentNullException(nameof(peopleApiWebClient));
            PeopleEventLogApiWebClient = peopleEventLogApiWebClient
                                         ?? throw new TeamManagerWebApiClientArgumentNullException(
                                             nameof(peopleEventLogApiWebClient));
            PositionApiWebClient = positionApiWebClient
                                   ?? throw new TeamManagerWebApiClientArgumentNullException(
                                       nameof(positionApiWebClient));
            TitleApiWebClient = titleApiWebClient
                                ?? throw new TeamManagerWebApiClientArgumentNullException(nameof(titleApiWebClient));
        }

        public CompanyApiWebClient CompanyApiWebClient { get; private set; }

        public EventApiWebClient EventApiWebClient { get; private set; }

        public PeopleApiWebClient PeopleApiWebClient { get; private set; }

        public PeopleEventLogApiWebClient PeopleEventLogApiWebClient { get; private set; }

        public PositionApiWebClient PositionApiWebClient { get; private set; }

        public TitleApiWebClient TitleApiWebClient { get; private set; }
    }
}