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
    public class PeopleController_DeleteAsync_Should : TestBase<People>
    {
        public PeopleController_DeleteAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, People> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PeopleApiWebClientDeleteAsynOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleApiWebClientArgumentNullException>();
        }

        public async Task Throw_PeopleApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            People p = new People();

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Throw_PeopleApiWebClientDeleteAsyncOperationException_WhenInputIdIsZero()
        {
            // Arrange
            People p = new People
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Delete_Item()
        {
            // Arrange
            People orig = new People
            {
                FirstName = "delete_firs",
                MiddleName = "delete_mid",
                LastName = "delete_last",
                IsActive = 1,
                PositionId = 1,
                CompanyId = 1,
                TitleId = 1
            };
            People origRecorded = await TeamManagerWebApiClient.PeopleApiWebClient.AddAsync(orig).ConfigureAwait(false);

            People toBeDeleted = new People
            {
                Id = origRecorded.Id
            };

            // Act
            await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(toBeDeleted).ConfigureAwait(false);

            // Assert
            List<People> result = await TeamManagerWebApiClient.PeopleApiWebClient.GetAllAsync().ConfigureAwait(false);

            People res = result.FirstOrDefault(p => p.FirstName == orig.FirstName && p.LastName == orig.LastName);
            res.Should().BeNull();
        }
    }
}