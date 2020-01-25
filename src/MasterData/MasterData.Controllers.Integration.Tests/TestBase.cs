namespace DigitalLibrary.MasterData.Controllers.Integration.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    using Microsoft.AspNetCore.Mvc.Testing;

    using Utils.DiLibHttpClient;
    using Utils.IntegrationTestFactories.Factories;

    using WebApi.Client;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [ExcludeFromCodeCoverage]
    public class TestBase<TTestedEntity> : IClassFixture<DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity>>
        where TTestedEntity : class
    {
        protected readonly WebApplicationFactory<Startup> _host;

        protected readonly IMasterDataHttpClient masterDataHttpClient;

        protected readonly ITestOutputHelper TestOutputHelper;

        public TestBase(DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity> host,
                        ITestOutputHelper testOutputHelper)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            TestOutputHelper = testOutputHelper;

            HttpClient httpClient = _host.CreateClient();
            DiLibHttpClient diLibHttpClient = new DiLibHttpClient(httpClient);
            masterDataHttpClient = new MasterDataHttpClient(diLibHttpClient);
        }
    }
}