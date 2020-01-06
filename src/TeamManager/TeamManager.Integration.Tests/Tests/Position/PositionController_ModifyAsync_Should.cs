namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Position
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Factories;

    using FluentAssertions;

    using WebApi.Client.Client.Position.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Position")]
    public class PositionController_ModifyAsync_Should : TestBase<Position>
    {
        public static IEnumerable<object[]> ThrowPositionApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid
            = new List<object[]>
            {
                new object[] { null, 1 },
                new object[] { string.Empty, 1 },
                new object[] { " ", 1 },

                new object[] { "asd", 0 },
            };

        public PositionController_ModifyAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Position> host,
                                                     ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PositionApiWebClientModifyAsyncOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PositionApiWebClient
                    .ModifyAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PositionApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<PositionApiWebClientArgumentNullException>();
        }

        [MemberData(nameof(ThrowPositionApiWebClientModifyAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_PositionApiWebClientModifyAsyncOperationException_WhenInputIsInvalid(
            string name,
            int isActive)
        {
            // Arrange
            Position p = new Position
            {
                Name = name,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PositionApiWebClient.ModifyAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PositionApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }
    }
}