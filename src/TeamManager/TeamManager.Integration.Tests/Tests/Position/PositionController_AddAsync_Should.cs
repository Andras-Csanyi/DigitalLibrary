namespace DigitalLibrary.IaC.TeamManager.Integration.Tests.Tests.Position
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
    using WebApi.Client.Client.Position.Exceptions;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Collection("DigitalLibrary.IaC.TeamManager.Integration.Tests.Position")]
    public class PositionController_AddAsync_Should : TestBase<Position>
    {
        public static IEnumerable<object[]> ThrowPositionApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid =
            new List<object[]>
            {
                new object[] { null, 1 },
                new object[] { string.Empty, 1 },
                new object[] { " ", 1 },

                new object[] { "asd", 2 },
            };

        public PositionController_AddAsync_Should(DiLibTeamManagerWebApplicationFactory<Startup, Position> host,
                                                  ITestOutputHelper testOutputHelper) : base(host, testOutputHelper)
        {
        }

        public async Task Throw_PositionApiWebClientAddAsyncOperationException_WhenInputIsNull()
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

        [MemberData(nameof(ThrowPositionApiWebClientAddAsyncOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_PositionApiWebClientAddAsyncOperationException_WhenInputIsInvalid(
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
                await TeamManagerWebApiClient.PositionApiWebClient.AddAsync(p).ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PositionApiWebClientAddAsyncOperationException>()
                .WithInnerExceptionExactly<HttpRequestException>();
        }

        public async Task Add_An_Item()
        {
            // Arrange
            Position position = new Position
            {
                Name = "new one",
                IsActive = 1
            };

            // Act
            Position result =
                await TeamManagerWebApiClient.PositionApiWebClient.AddAsync(position).ConfigureAwait(false);

            // Assert
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(position.Name);
            result.IsActive.Should().Be(position.IsActive);

            List<Position> list = await TeamManagerWebApiClient.PositionApiWebClient.GetAllAsync()
                .ConfigureAwait(false);
            Position res = list.FirstOrDefault(k => k.Name == position.Name);

            res.Id.Should().Be(result.Id);
            res.Name.Should().Be(position.Name);
            res.IsActive.Should().Be(position.IsActive);
        }
    }
}