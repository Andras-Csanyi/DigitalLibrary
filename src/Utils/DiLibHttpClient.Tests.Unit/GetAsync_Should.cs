namespace DiLibHttpClient.Tests.Unit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class GetAsync_Should : TestBase
    {
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
                await DiLibHttpClient.GetAsync<Example>(url)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}
