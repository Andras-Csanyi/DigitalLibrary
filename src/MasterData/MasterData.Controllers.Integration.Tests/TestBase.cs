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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "CA1707")]
    [SuppressMessage("ReSharper", "NotAccessedField.Global")]
    [SuppressMessage("ReSharper", "CA1051")]
    public class TestBase<TTestedEntity> : IClassFixture<DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity>>
        where TTestedEntity : class
    {
        protected readonly WebApplicationFactory<Startup> _host;

        protected readonly IMasterDataHttpClient _masterDataHttpClient;

        protected readonly ITestOutputHelper _testOutputHelper;

        protected TestBase(DiLibMasterDataWebApplicationFactory<Startup, TTestedEntity> host,
                           ITestOutputHelper testOutputHelper)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _testOutputHelper = testOutputHelper;

            HttpClient httpClient = _host.CreateClient();
            DiLibHttpClient diLibHttpClient = new DiLibHttpClient(httpClient);
            _masterDataHttpClient = new MasterDataHttpClient(diLibHttpClient);
        }
    }
}