namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is requested with DimensionStructure tree")]
        public async Task SourceFormatIsRequestedWithDimensionStructureTree(Table table)
        {
            Check.IsNotNull(table);
            SourceFormatIsRequestedWithDimensionStructureTreeEntity instance = table
               .CreateInstance<SourceFormatIsRequestedWithDimensionStructureTreeEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    internal class SourceFormatIsRequestedWithDimensionStructureTreeEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}