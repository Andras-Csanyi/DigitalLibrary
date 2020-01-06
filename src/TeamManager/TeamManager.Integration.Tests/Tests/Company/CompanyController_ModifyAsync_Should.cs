namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Company
{
    using System;
    using System.Collections.Generic;
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
    public class CompanyController_ModifyAsync_Should : TestBase<Company>
    {
        public static IEnumerable<object[]> ThrowCompanyApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { 1, null, "asd", "asd", 1 },
                new object[] { 1, string.Empty, "asd", "asd", 1 },
                new object[] { 1, " ", "asd", "asd", 1 },

                new object[] { 1, "asd", null, "asd", 1 },
                new object[] { 1, "asd", string.Empty, "asd", 1 },
                new object[] { 1, "asd", " ", "asd", 1 },

                new object[] { 1, "asd", "asd", null, 1 },
                new object[] { 1, "asd", "asd", string.Empty, 1 },
                new object[] { 1, "asd", "asd", " ", 1 },

                new object[] { 0, "asd", "asd", "asd", 1 },
            };

        public static IEnumerable<object[]> ModifyAnItem = new List<object[]>
        {
            new object[] { "modif", string.Empty, string.Empty, 1 },
            new object[] { string.Empty, "modif", string.Empty, 1 },
            new object[] { string.Empty, string.Empty, "modif", 1 },
            new object[] { string.Empty, string.Empty, string.Empty, 0 },
        };

        public CompanyController_ModifyAsync_Should(
            DiLibTeamManagerWebApplicationFactory<Startup, Company> host,
            ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        private async Task Throw_CompanyApiWebClientModifyAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.CompanyApiWebClient.ModifyAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<CompanyApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowCompanyApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_CompanyApiWebClientModifyAsyncOperationException_WhenInputIsInvalid(
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
                await TeamManagerWebApiClient.CompanyApiWebClient.ModifyAsync(c).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }


        [MemberData(nameof(ModifyAnItem))]
        public async Task Modify_An_Item(
            string name,
            string desc,
            string url,
            int isActive)
        {
            // Arrange
            Company orig = new Company
            {
                Name = "orig",
                Description = "orig",
                Url = "orig",
                IsActive = 1
            };
            Company origResult = await TeamManagerWebApiClient.CompanyApiWebClient.AddAsync(orig)
                .ConfigureAwait(false);

            string nameModif = origResult.Name + name;
            string descModif = origResult.Description + desc;
            string urlModif = origResult.Url + url;

            origResult.Name = nameModif;
            origResult.Description = descModif;
            origResult.Url = urlModif;
            origResult.IsActive = isActive;

            // Act
            Company modifResult = await TeamManagerWebApiClient.CompanyApiWebClient.ModifyAsync(origResult)
                .ConfigureAwait(false);

            // Assert
            modifResult.Name.Should().Be(nameModif);
            modifResult.Description.Should().Be(descModif);
            modifResult.Url.Should().Be(urlModif);
            modifResult.IsActive.Should().Be(isActive);
        }
    }
}