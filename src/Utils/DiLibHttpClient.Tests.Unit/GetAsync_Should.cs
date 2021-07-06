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

        [Fact]
        public async Task Return_CustomResponseObject_WhenCallIsFailing()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            HandlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(httpResponseMessage);

            DilibHttpClientResponse<Example> result = await DiLibHttpClient.GetAsync<Example>(
                    AbsoluteUri)
               .ConfigureAwait(false);

            result.Should().BeOfType<DilibHttpClientResponse<Example>>();
            result.IsSuccess.Should().BeFalse();
            result.HttpStatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            result.Exception.Should().BeOfType<HttpRequestException>();
        }

        [Fact]
        public async Task Return_CustomResponseObject_WhenCallIsSuccessful()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{ ""result"":""success""}"),
            };

            HandlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(httpResponseMessage);

            DilibHttpClientResponse<ExampleResult> exampleResult = await DiLibHttpClient.GetAsync<ExampleResult>(
                    AbsoluteUri)
               .ConfigureAwait(false);

            exampleResult.Should().BeOfType<DilibHttpClientResponse<ExampleResult>>();
            exampleResult.IsSuccess.Should().BeTrue();
            exampleResult.HttpStatusCode.Should().Be((int)HttpStatusCode.OK);
            exampleResult.Result.Should().BeOfType<ExampleResult>();
            exampleResult.Result.Result.Should().Be("success");
        }
    }
}
