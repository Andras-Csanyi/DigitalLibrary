namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Title
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    public class TitleController_DeleteAsync_Should : TestBase<Title>
    {
        public TitleController_DeleteAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Title> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_TitleApiWebClientDeleteAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.TitleApiWebClient.DeleteAsync(null).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientDeleteAsyncOperationException>()
                .WithInnerException<TitleApiWebClientArgumentNullException>();
        }

        public async Task Throw_TitleApiWebClientDeleteAsyncOperationException_WhenInputIsInvalid()
        {
            // Arrange
            Title t = new Title
            {
                Id = 0
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.TitleApiWebClient.DeleteAsync(t).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<TitleApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Delete_An_Item()
        {
            // Arrange
            Title t = new Title
            {
                Id = 2
            };
            List<Title> origList = await TeamManagerWebApiClient.TitleApiWebClient.GetAllAsync()
                .ConfigureAwait(false);

            // Act
            await TeamManagerWebApiClient.TitleApiWebClient.DeleteAsync(t).ConfigureAwait(false);

            // Assert
            List<Title> afterDelete = await TeamManagerWebApiClient.TitleApiWebClient
                .GetAllAsync()
                .ConfigureAwait(false);

            afterDelete.Count.Should().Be(origList.Count - 1);

            Title res = afterDelete.FirstOrDefault(w => w.Id == t.Id);
            res.Should().BeNull();
        }
    }
}