namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.TeamManagerWebApiClient.cs
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client;
    using Client.Company;
    using Client.Event;
    using Client.Exceptions;
    using Client.People;
    using Client.PeopleEventLog;
    using Client.Position;
    using Client.Title;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class Ctor_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowExceptionWhenInputIsNull = new List<object[]>
        {
            new object[]
            {
                null,
                new EventApiWebClient(new HttpClient()),
                new PeopleApiWebClient(new HttpClient()),
                new PeopleEventLogApiWebClient(new HttpClient()),
                new PositionApiWebClient(new HttpClient()),
                new TitleApiWebClient(new HttpClient())
            },
            new object[]
            {
                new CompanyApiWebClient(new HttpClient()),
                null,
                new PeopleApiWebClient(new HttpClient()),
                new PeopleEventLogApiWebClient(new HttpClient()),
                new PositionApiWebClient(new HttpClient()),
                new TitleApiWebClient(new HttpClient())
            },
            new object[]
            {
                new CompanyApiWebClient(new HttpClient()),
                new EventApiWebClient(new HttpClient()),
                null,
                new PeopleEventLogApiWebClient(new HttpClient()),
                new PositionApiWebClient(new HttpClient()),
                new TitleApiWebClient(new HttpClient())
            },
            new object[]
            {
                new CompanyApiWebClient(new HttpClient()),
                new EventApiWebClient(new HttpClient()),
                new PeopleApiWebClient(new HttpClient()),
                null,
                new PositionApiWebClient(new HttpClient()),
                new TitleApiWebClient(new HttpClient())
            },
            new object[]
            {
                new CompanyApiWebClient(new HttpClient()),
                new EventApiWebClient(new HttpClient()),
                new PeopleApiWebClient(new HttpClient()),
                new PeopleEventLogApiWebClient(new HttpClient()),
                null,
                new TitleApiWebClient(new HttpClient())
            },
            new object[]
            {
                new CompanyApiWebClient(new HttpClient()),
                new EventApiWebClient(new HttpClient()),
                new PeopleApiWebClient(new HttpClient()),
                new PeopleEventLogApiWebClient(new HttpClient()),
                new PositionApiWebClient(new HttpClient()),
                null
            },
        };

        [MemberData(nameof(ThrowExceptionWhenInputIsNull))]
        [Trait("Category", "Unit")]
        public async Task ThrowException_WhenInputIsNull(
            CompanyApiWebClient companyApiWebClient,
            EventApiWebClient eventApiWebClient,
            PeopleApiWebClient peopleApiWebClient,
            PeopleEventLogApiWebClient peopleEventLogApiWebClient,
            PositionApiWebClient positionApiWebClient,
            TitleApiWebClient titleApiWebClient)
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                TeamManagerWebApiClient client = new TeamManagerWebApiClient(
                    companyApiWebClient,
                    eventApiWebClient,
                    peopleApiWebClient,
                    peopleEventLogApiWebClient,
                    positionApiWebClient,
                    titleApiWebClient
                );
            };

            // Assert
            action.Should().ThrowExactly<TeamManagerWebApiClientArgumentNullException>();
        }
    }
}