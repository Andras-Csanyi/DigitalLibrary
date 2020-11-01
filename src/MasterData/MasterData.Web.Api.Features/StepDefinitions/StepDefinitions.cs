using IMasterDataHttpClient = MasterData.Web.Api.Client.Interfaces.IMasterDataHttpClient;

namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Linq;
    using System.Net.Http;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.WebApi.Client;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
    using DigitalLibrary.Utils.MasterDataTestHelper;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using TechTalk.SpecFlow;

    using WebApp;

    using Xunit;
    using Xunit.Abstractions;

    [Binding]
    public partial class StepDefinitions : IClassFixture<TestBase<Startup>>
    {
        private ScenarioContext _scenarioContext;

        private readonly IMasterDataTestHelper _masterDataTestHelper;

        private readonly ITestOutputHelper _testOutputHelper;

        protected readonly WebApplicationFactory<Startup> _host;

        private readonly IMasterDataHttpClient _masterDataHttpClient;

        public StepDefinitions(
            ScenarioContext scenarioContext,
            ITestOutputHelper testOutputHelper,
            WebApplicationFactory<Startup> host)
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
            _masterDataTestHelper = new MasterDataTestHelper(sourceFormatFactory, dimensionStructureFactory);

            HttpClient httpClient = _host.CreateClient();
            DiLibHttpClient diLibHttpClient = new DiLibHttpClient(httpClient);
            _masterDataHttpClient = new MasterDataHttpClient(diLibHttpClient);
        }


        [Then(@"The result SourceFormat has the following properties")]
        public void ThenTheResultSourceFormatHasTheFollowingProperties(Table table)
        {
            _scenarioContext.Pending();
        }
    }
}