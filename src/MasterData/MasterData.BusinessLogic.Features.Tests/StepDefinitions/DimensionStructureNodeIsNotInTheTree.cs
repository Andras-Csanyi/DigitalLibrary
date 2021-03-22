namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is not in the tree")]
        public async Task DimensionStructureNodeIsNotInTheTree(Table table)
        {
            DimensionStructureNodeIsNotInTheTreeEntity instance = table
               .CreateInstance<DimensionStructureNodeIsNotInTheTreeEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.SearchForObjectKey]
                as DimensionStructureNode;

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            DimensionStructureNode found = await FindDimensionStructureNodeInTree(result, dimensionStructureNode)
               .ConfigureAwait(false);
        }
    }

    internal class DimensionStructureNodeIsNotInTheTreeEntity
    {
        public string Key { get; set; }

        public string SearchForObjectKey { get; set; }
    }
}