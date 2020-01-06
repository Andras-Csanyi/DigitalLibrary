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
    public class CompanyController_AddAsync_Should : TestBase<Company>
    {
        public static IEnumerable<object[]> ThrowCompanyApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { 0, null, "asd", "asd", 1 },
                new object[] { 0, string.Empty, "asd", "asd", 1 },
                new object[] { 0, " ", "asd", "asd", 1 },

                new object[] { 0, "asd", null, "asd", 1 },
                new object[] { 0, "asd", string.Empty, "asd", 1 },
                new object[] { 0, "asd", " ", "asd", 1 },

                new object[] { 0, "asd", "asd", null, 1 },
                new object[] { 0, "asd", "asd", string.Empty, 1 },
                new object[] { 0, "asd", "asd", " ", 1 },

                new object[] { 1, "asd", "asd", "asd", 1 },
            };

        public CompanyController_AddAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, Company> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        private async Task Throw_CompanyApiWebClientAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.CompanyApiWebClient.AddAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<CompanyApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowCompanyApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_CompanyApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
            long id,
            string name,
            string description,
            string url,
            int isActive)
        {
            // Arrange
            Company c = new Company
            {
                Id = id,
                Name = name,
                Description = description,
                Url = url,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.CompanyApiWebClient.AddAsync(c).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }


        public async Task Add_AnItem()
        {
            // Arrange
            Company c = new Company
            {
                Id = 0,
                Name = "new one",
                Description = "descccc",
                Url = "url",
                IsActive = 1
            };

            // Act
            Company result = await TeamManagerWebApiClient.CompanyApiWebClient.AddAsync(c).ConfigureAwait(false);

            // Assert
            List<Company> list = await TeamManagerWebApiClient.CompanyApiWebClient.GetAllAsync().ConfigureAwait(false);

            Company res = list.FirstOrDefault(p => p.Name.Equals(c.Name));
            res.Name.Should().Be(c.Name);
            res.Description.Should().Be(c.Description);
            res.Url.Should().Be(c.Url);
            res.IsActive.Should().Be(c.IsActive);

            // Cleanup
            await TeamManagerWebApiClient.CompanyApiWebClient.DeleteAsync(res).ConfigureAwait(false);
        }
    }
}