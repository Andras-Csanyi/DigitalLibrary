namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.PeopleEventLogApiWebClient
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client.PeopleEventLog.Exceptions;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class ModifyAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.ModifyAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleEventLogApiWebClientArgumentNullException>();
        }
    }
}