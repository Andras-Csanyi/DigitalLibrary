namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.People
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.People.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.People")]
    public class PeopleController_ModifyAsync_Should : TestBase<People>
    {
        public static IEnumerable<object[]> ThrowPeopleApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { null, "asd", "asd", 1, 1, 1, 1 },
                new object[] { string.Empty, "asd", "asd", 1, 1, 1, 1 },
                new object[] { " ", "asd", "asd", 1, 1, 1, 1 },

                new object[] { "asd", null, "asd", 1, 1, 1, 1 },
                new object[] { "asd", string.Empty, "asd", 1, 1, 1, 1 },
                new object[] { "asd", " ", "asd", 1, 1, 1, 1 },

                new object[] { "asd", "asd", null, 1, 1, 1, 1 },
                new object[] { "asd", "asd", string.Empty, 1, 1, 1, 1 },
                new object[] { "asd", "asd", " ", 1, 1, 1, 1 },

                new object[] { "asd", "asd", "asd", 2, 1, 1, 1 },

                new object[] { "asd", "asd", "asd", 1, 100, 1, 1 },

                new object[] { "asd", "asd", "asd", 1, 1, 100, 1 },

                new object[] { "asd", "asd", "asd", 1, 1, 1, 100 },
            };

        public PeopleController_ModifyAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, People> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PeopleApiWebClientModifyAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.ModifyAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowPeopleApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_PeopleApiWebClientModifyAsyncOperationException_WhenInputIsInvalid(
            string firstName,
            string middleName,
            string lastName,
            int isActive,
            long titleId,
            long companyId,
            long positionId)
        {
            // Arrange
            People p = new People
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                IsActive = isActive,
                TitleId = titleId,
                CompanyId = companyId,
                PositionId = positionId
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.ModifyAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientModifyAsyncOperationException>();
        }
    }
}