// [assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]

namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net.Http;

    using DigitalLibrary.MasterData.Web.Api.Client.Interfaces;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.MasterData.WebApi.Client.DimensionStructure;
    using DigitalLibrary.MasterData.WebApi.Client.DimensionStructureNode;
    using DigitalLibrary.MasterData.WebApi.Client.SourceFormat;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

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

        private IMasterDataTestHelper _masterDataTestHelper;

        private readonly ITestOutputHelper _testOutputHelper;

        private IMasterDataHttpClient _masterDataHttpClient;

        private string _entityNameWithPath;

        private Random rnd = new Random();

        protected readonly WebApiFeatureTestApplicationFactory<Startup> _host;

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
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            int random = rnd.Next(1, 10000000);
            string directoryPath = Directory.GetCurrentDirectory();
            _entityNameWithPath = $"{directoryPath}/master_data_integration_test_{random}.sql";
            _host.EntityName = _entityNameWithPath;

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
            IDimensionStructureNodeHttpClient dimensionStructureNodeHttpClient =
                new DimensionStructureNodeHttpClient(diLibHttpClient);

            _masterDataHttpClient = new MasterDataHttpClient(
                sourceFormatHttpClientHttpClient,
                dimensionStructureHttpClient,
                dimensionStructureNodeHttpClient);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            File.Delete(_entityNameWithPath);
        }
    }
}
