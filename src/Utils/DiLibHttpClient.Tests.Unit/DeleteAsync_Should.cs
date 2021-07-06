namespace DiLibHttpClient.Tests.Unit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using Moq;
    using Moq.Protected;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DeleteAsync_Should : TestBase
    {
        [Fact]
        public void Throw_WhenPayloadIsNull()
        {
            // Action
            Func<Task> action = async () =>
            {
                await DiLibHttpClient.DeleteAsync<Example>(ExampleUrl, null)
                   .ConfigureAwait(false);
            };

            // Assert
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
                await DiLibHttpClient.DeleteAsync<Example>(url, null)
                   .ConfigureAwait(false);
            };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }

        [Fact]
        public async Task Return_CustomResponseObject_WhenCallIsSuccessful()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            };
            Example example = new Example();

            HandlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(httpResponseMessage);

            DilibHttpClientResponse<Example> result = await DiLibHttpClient.DeleteAsync<Example>(
                    AbsoluteUri, example)
               .ConfigureAwait(false);

            result.Should().BeOfType<DilibHttpClientResponse<Example>>();
            result.IsSuccess.Should().BeTrue();
            result.HttpStatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task Return_CustomResponseObject_WhenCallIsFailed()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
            };
            Example example = new Example();

            HandlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(httpResponseMessage);

            DilibHttpClientResponse<Example> result = await DiLibHttpClient.DeleteAsync<Example>(
                    AbsoluteUri, example)
               .ConfigureAwait(false);

            result.Should().BeOfType<DilibHttpClientResponse<Example>>();
            result.IsSuccess.Should().BeFalse();
            result.HttpStatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            result.Exception.Should().BeOfType<HttpRequestException>();
        }
    }
}
