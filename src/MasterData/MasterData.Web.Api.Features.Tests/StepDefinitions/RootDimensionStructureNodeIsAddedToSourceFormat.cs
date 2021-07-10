namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"root DimensionStructureNode is added to SourceFormat")]
        [When(@"root DimensionStructureNode is added to SourceFormat")]
        public async Task RootDimensionStructureNodeIsAddedToSourceFormat(Table table)
        {
            RootDimensionStructureNodeIsAddedToSourceFormatEntity instance = table
               .CreateInstance<RootDimensionStructureNodeIsAddedToSourceFormatEntity>();

            SourceFormat sf = _scenarioContext.Get<SourceFormat>(instance.SourceFormatResultKey);
            Check.IsNotNull(sf);
            DimensionStructureNode dsn = _scenarioContext.Get<DimensionStructureNode>(
                instance.DimensionStructureNodeResultKey);
            Check.IsNotNull(dsn);

            AddRootDimensionStructureNodeViewModel vm = new AddRootDimensionStructureNodeViewModel()
            {
                DimensionStructureNodeId = dsn.Id,
                SourceFormatId = sf.Id,
            };

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient.SourceFormatHttpClient
               .AddRootDimensionStructureNodeAsync(vm)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class RootDimensionStructureNodeIsAddedToSourceFormatEntity
    {
        public string SourceFormatResultKey { get; set; }

        public string DimensionStructureNodeResultKey { get; set; }

        public string ResultKey { get; set; }
    }
}
