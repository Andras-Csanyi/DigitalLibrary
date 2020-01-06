namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.PeopleApiWebClient
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client.People.Exceptions;

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
                await TeamManagerWebApiClient.PeopleApiWebClient.DeleteAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<PeopleApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<PeopleApiWebClientArgumentNullException>();
        }
    }
}