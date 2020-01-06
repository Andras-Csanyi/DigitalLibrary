namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.CompanyApiWebClient
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client.Company.Exceptions;

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
                await TeamManagerWebApiClient.CompanyApiWebClient.DeleteAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientDeleteAsyncOperationException>()
                .WithInnerExceptionExactly<CompanyApiWebClientArgumentNullException>();
        }
    }
}