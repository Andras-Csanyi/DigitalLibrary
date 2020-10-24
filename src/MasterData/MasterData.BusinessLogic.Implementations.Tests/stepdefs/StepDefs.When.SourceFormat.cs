namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.stepdefs
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [When(@"SourceFormat is requested with DimensionStructure tree")]
        public async Task SourceFormatIsRequestedWithDimensionStructureTree(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(string key, string resultKey)>();

            SourceFormat sourceFormat = _scenarioContext[instance.key] as SourceFormat;

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.resultKey, result);
        }

        [When(@"SourceFormat is requested with root DimensionStructure")]
        public async Task SourceFormatIsRequestedWithRootDimensionStructure(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            DomainModel.SourceFormat withoutTree = _scenarioContext[instance.key] as SourceFormat;

            DomainModel.SourceFormat requestedWithTree = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureAsync(withoutTree)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.resultKey, requestedWithTree);
        }
    }
}