namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Title
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.Title.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Title")]
    public class TitleController_AddAsync_Should : TestBase<Title>
    {
        public static IEnumerable<object[]> ThrowTitleApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid
            = new List<object[]>
            {
                new object[] { null, 1 },
                new object[] { string.Empty, 1 },
                new object[] { " ", 1 },

                new object[] { "asdasd", 2 },
            };

        public TitleController_AddAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Title> host,
                                               ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_TitleApiWebClientAddAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.TitleApiWebClient.AddAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientAddAsyncOperationException>()
                .WithInnerException<TitleApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowTitleApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_TitleApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
            string name,
            int isActive)
        {
            // Arrange
            Title t = new Title
            {
                Name = name,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.TitleApiWebClient.AddAsync(t).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientAddAsyncOperationException>()
                .WithInnerException<HttpRequestException>();
        }

        public async Task Add_An_Item()
        {
            // Arrange
            Title t = new Title
            {
                Name = "new one",
                IsActive = 1
            };

            // Act
            Title result = await TeamManagerWebApiClient.TitleApiWebClient.AddAsync(t).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(t.Name);
            result.IsActive.Should().Be(t.IsActive);
        }
    }
}