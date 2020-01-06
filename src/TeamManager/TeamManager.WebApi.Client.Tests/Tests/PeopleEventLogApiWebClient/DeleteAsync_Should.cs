namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.PeopleEventLogApiWebClient
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client.PeopleEventLog.Exceptions;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class DeleteAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () =>
            {
                await TeamManagerWebApiClient.PeopleEventLogApiWebClient.DeleteAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleEventLogApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleEventLogApiWebClientArgumentNullException>();
        }
    }
}