[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]

namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.MasterData.WebApi.Client.DimensionStructure;
    using DigitalLibrary.MasterData.WebApi.Client.DimensionStructureNode;
    using DigitalLibrary.MasterData.WebApi.Client.SourceFormat;
    using DigitalLibrary.MasterData.WebApi.Client.SourceFormatDimensionStructureNode;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using Microsoft.AspNetCore.Mvc.Testing;

    using TechTalk.SpecFlow;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Binding]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class StepDefinitions : IClassFixture<WebApiFeatureTestApplicationFactory<Startup>>
    {
        private ScenarioContext _scenarioContext;

        private readonly IMasterDataTestHelper _masterDataTestHelper;

        private readonly ITestOutputHelper _testOutputHelper;

        protected readonly WebApplicationFactory<Startup> _host;

        private readonly IMasterDataHttpClient _masterDataHttpClient;

        public StepDefinitions(
            ScenarioContext scenarioContext,
            ITestOutputHelper testOutputHelper,
            WebApiFeatureTestApplicationFactory<Startup> host)
        {
            Check.IsNotNull(scenarioContext);
            _scenarioContext = scenarioContext;

            Check.IsNotNull(testOutputHelper);
            _testOutputHelper = testOutputHelper;

            Check.IsNotNull(host);
            _host = host;

            IStringHelper stringHelper = new StringHelper();
            ISourceFormatFactory sourceFormatFactory = new SourceFormatFactory(stringHelper);
            IDimensionStructureFactory dimensionStructureFactory = new DimensionStructureFactory(stringHelper);
            ISourceFormatDimensionStructureNodeFactory sourceFormatDimensionStructureNodeFactory
                = new SourceFormatDimensionStructureNodeFactory();
            _masterDataTestHelper = new MasterDataTestHelper(
                sourceFormatFactory,
                dimensionStructureFactory,
                sourceFormatDimensionStructureNodeFactory);

            HttpClient httpClient = _host.CreateClient();
            DiLibHttpClient diLibHttpClient = new DiLibHttpClient(httpClient);
            SourceFormatHttpClientHttpClient sourceFormatHttpClientHttpClient = new SourceFormatHttpClientHttpClient(
                diLibHttpClient);
            IDimensionStructureHttpClient dimensionStructureHttpClient = new DimensionStructureHttpClientHttpClient(
                diLibHttpClient);
            ISourceFormatDimensionStructureNodeHttpClient sourceFormatDimensionStructureNodeHttpClient =
                new SourceFormatDimensionStructureNodeHttpClient(diLibHttpClient);
            IDimensionStructureNodeHttpClient dimensionStructureNodeHttpClient =
                new DimensionStructureNodeHttpClient(diLibHttpClient);

            _masterDataHttpClient = new MasterDataHttpClient(
                sourceFormatHttpClientHttpClient,
                dimensionStructureHttpClient,
                sourceFormatDimensionStructureNodeHttpClient,
                dimensionStructureNodeHttpClient);
        }
    }
}