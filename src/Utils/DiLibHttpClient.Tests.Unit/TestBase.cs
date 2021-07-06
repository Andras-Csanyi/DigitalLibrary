namespace DiLibHttpClient.Tests.Unit
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.DiLibHttpClient;

    using Moq;
    using Moq.Protected;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected readonly IDiLibHttpClient DiLibHttpClient;

        protected readonly Mock<HttpMessageHandler> HandlerMock;

        protected const string ExampleUrl = "/url";

        protected const string AbsoluteUri = "http://example.com/asd";

        public TestBase()
        {
            HandlerMock = new Mock<HttpMessageHandler>();
            HandlerMock.Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
            var httpClient = new HttpClient(HandlerMock.Object);
            DiLibHttpClient = new DiLibHttpClient(httpClient);
        }
    }
}
