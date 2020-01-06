namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.People.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.People")]
    public class PeopleController_AddAsync_Should : TestBase<People>
    {
        public static IEnumerable<object[]> ThrowPeopleApiWebClientAddAsyncOperationException_WhenInputIsInvalid =
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

        public PeopleController_AddAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, People> host,
                                                ITestOutputHelper testOutputHelper)
            : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PeopleApiWebClientAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.AddAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowPeopleApiWebClientAddAsyncOperationException_WhenInputIsInvalid))]
        public async Task Throw_PeopleApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
            string firstName,
            string middleName,
            string lastName,
            int isActive,
            long companyId,
            long positionId,
            long titleId)
        {
            // Arrange
            People p = new People
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                IsActive = isActive,
                CompanyId = companyId,
                PositionId = positionId,
                TitleId = titleId
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.AddAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task AddPeope_AndReturnWithIt()
        {
            // Arrange
            People orig = new People
            {
                FirstName = "firstname",
                MiddleName = "middlename",
                LastName = "lastname",
                IsActive = 1,
                CompanyId = 1,
                PositionId = 1,
                TitleId = 1
            };

            // Act
            People result = await TeamManagerWebApiClient.PeopleApiWebClient.AddAsync(orig).ConfigureAwait(false);

            // Assert
            result.FirstName.Should().Be(orig.FirstName);
            result.MiddleName.Should().Be(orig.MiddleName);
            result.LastName.Should().Be(orig.LastName);
            result.IsActive.Should().Be(orig.IsActive);
            result.CompanyId.Should().Be(orig.CompanyId);
            result.TitleId.Should().Be(orig.TitleId);
            result.PositionId.Should().Be(orig.PositionId);
            result.PositionId.Should().Be(orig.PositionId);

            List<People> list = await TeamManagerWebApiClient.PeopleApiWebClient.GetAllAsync().ConfigureAwait(false);
            People theOne = list.FirstOrDefault(p => p.FirstName == orig.FirstName && p.LastName == orig.LastName);

            theOne.FirstName.Should().Be(orig.FirstName);
            theOne.MiddleName.Should().Be(orig.MiddleName);
            theOne.LastName.Should().Be(orig.LastName);
            theOne.IsActive.Should().Be(orig.IsActive);
            theOne.CompanyId.Should().Be(orig.CompanyId);
            theOne.TitleId.Should().Be(orig.TitleId);
            theOne.PositionId.Should().Be(orig.PositionId);
            theOne.PositionId.Should().Be(orig.PositionId);

            // Cleanup
            await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(result).ConfigureAwait(false);
        }
    }
}