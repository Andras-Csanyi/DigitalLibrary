namespace DiLibHttpClient.Tests.Unit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class PostAsync_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenPayloadIsNull()
        {
            Func<Task> action = async () =>
            {
                await DiLibHttpClient.DeleteAsync<Example>("/asdasd", null)
                   .ConfigureAwait(false);
            };

            action.Should().ThrowExactly<GuardException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Throw_WhenUrlIs_NullEmptyOrWhiteSpace(
            string url)
        {
            // Action
            Func<Task> action = async () =>
            {
                await DiLibHttpClient.PostAsync<Example>(url, null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
