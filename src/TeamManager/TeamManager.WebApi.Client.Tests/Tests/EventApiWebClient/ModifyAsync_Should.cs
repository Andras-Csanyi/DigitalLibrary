namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Tests.Tests.EventApiWebClient
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Client.Company.Exceptions;

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
                await TeamManagerWebApiClient.CompanyApiWebClient.ModifyAsync(null)
                    .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<CompanyApiWebClientModifyAsyncOperationException>()
                .WithInnerExceptionExactly<CompanyApiWebClientArgumentNullException>();
        }
    }
}