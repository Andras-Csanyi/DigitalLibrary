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
    public class TitleController_ModifyAsync_Should : TestBase<Title>
    {
        public static IEnumerable<object[]> ThrowTitleApiWebclientModifyAsyncOperationExceptionWhenInputIsInvalid
            = new List<object[]>
            {
                new object[] { null, 1 },
                new object[] { string.Empty, 1 },
                new object[] { " ", 1 },

                new object[] { "asd", 2 },
            };

        public static IEnumerable<object[]> ModifyAnItem = new List<object[]>
        {
            new object[] { "name", 1 },
            new object[] { "name2", 0 },
        };

        public TitleController_ModifyAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Title> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_TitleApiWebClientModifyAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.TitleApiWebClient.ModifyAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<TitleApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowTitleApiWebclientModifyAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_TitleApiWebclientModifyAsyncOperationException_WhenInputIsInvalid(
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
                await TeamManagerWebApiClient.TitleApiWebClient.ModifyAsync(t).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        [MemberData(nameof(ModifyAnItem))]
        public async Task Modify_An_Item(
            string name,
            int isActive)
        {
            // Arrange
            Title t = new Title
            {
                Id = 2,
                Name = name,
                IsActive = isActive
            };

            // Act
            Title res = await TeamManagerWebApiClient.TitleApiWebClient.ModifyAsync(t).ConfigureAwait(false);

            // Assert
            res.Id.Should().Be(t.Id);
            res.Name.Should().Be(t.Name);
            res.IsActive.Should().Be(t.IsActive);
        }
    }
}