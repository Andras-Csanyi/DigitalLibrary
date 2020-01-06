namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.Company.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Company")]
    public class CompanyController_DeleteAsync_Should : TestBase<Company>
    {
        public CompanyController_DeleteAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Company> host,
                                                    ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_CompanyApiWebClientDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.CompanyApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<CompanyApiWebClientArgumentNullException>();
        }

        public async Task Throw_CompanyApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            Company c = new Company
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.CompanyApiWebClient.DeleteAsync(c).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Delete_An_Item()
        {
            // Arrange
            Company c = new Company
            {
                Name = "aaaaaa",
                Description = "aaaaaaaa",
                Url = "urllll"
            };

            Company addResult = await TeamManagerWebApiClient.CompanyApiWebClient.AddAsync(c).ConfigureAwait(false);
            List<Company> addResultList = await TeamManagerWebApiClient.CompanyApiWebClient.GetAllAsync()
                .ConfigureAwait(false);
            int resultSize = addResultList.Count;

            // Act
            await TeamManagerWebApiClient.CompanyApiWebClient.DeleteAsync(addResult).ConfigureAwait(false);

            // Assert
            List<Company> assertList = await TeamManagerWebApiClient.CompanyApiWebClient.GetAllAsync().ConfigureAwait
                (false);
            assertList.Count.Should().Be(resultSize - 1);
            Company res = assertList.FirstOrDefault(p => p.Name.Equals(c.Name));
            res.Should().BeNull();
        }
    }
}