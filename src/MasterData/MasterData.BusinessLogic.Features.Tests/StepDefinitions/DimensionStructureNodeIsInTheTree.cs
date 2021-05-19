namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is in the tree by traversing through the tree")]
        public async Task DimensionStructureNodeIsInTheTreeByTraversingThroughTheTree(Table table)
        {
            DimensionStructureNodeLookupInTheTreeEntity instance = table
               .CreateInstance<DimensionStructureNodeLookupInTheTreeEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.SearchForObjectKey]
                as DimensionStructureNode;

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            DimensionStructureNode found = await FindDimensionStructureNodeInTree(result, dimensionStructureNode)
               .ConfigureAwait(false);
            found.Should().NotBeNull();
        }
    }
}
