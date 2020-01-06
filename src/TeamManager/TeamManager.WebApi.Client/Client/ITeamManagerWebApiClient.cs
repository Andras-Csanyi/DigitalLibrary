namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client
{
    using Company;

    using Event;

    using People;

    using PeopleEventLog;

    using Position;

    using Title;

    public interface ITeamManagerWebApiClient
    {
        CompanyApiWebClient CompanyApiWebClient { get; }

        EventApiWebClient EventApiWebClient { get; }

        PeopleApiWebClient PeopleApiWebClient { get; }

        PeopleEventLogApiWebClient PeopleEventLogApiWebClient { get; }

        PositionApiWebClient PositionApiWebClient { get; }

        TitleApiWebClient TitleApiWebClient { get; }
    }
}