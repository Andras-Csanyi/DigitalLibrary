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
    public class PutAsync_Should : TestBase
    {
        [Fact]
        public async Task Throw_WhenPayloadIsNull()
        {
            Func<Task> action = async () =>
            {
                await DiLibHttpClient.PutAsync<Example>("/asdasd", null)
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
                await DiLibHttpClient.PutAsync<Example>(url, null)
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

            DilibHttpClientResponse<Example> result = await DiLibHttpClient.PutAsync<Example>(
                    AbsoluteUri, new Example())
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

            DilibHttpClientResponse<ExampleResult> exampleResult = await DiLibHttpClient.PutAsync<ExampleResult>(
                    AbsoluteUri, new ExampleResult())
               .ConfigureAwait(false);

            exampleResult.Should().BeOfType<DilibHttpClientResponse<ExampleResult>>();
            exampleResult.IsSuccess.Should().BeTrue();
            exampleResult.HttpStatusCode.Should().Be((int)HttpStatusCode.OK);
            exampleResult.Result.Should().BeOfType<ExampleResult>();
            exampleResult.Result.Result.Should().Be("success");
        }
    }
}
