namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode parent by traversing through the tree is")]
        public async Task DimensionStructureNodeParentByTraversingThroughTheTreeIs(Table table)
        {
            DimensionStructureNodeAndParentLookupInTheTreeEntity instance = table
               .CreateInstance<DimensionStructureNodeAndParentLookupInTheTreeEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.TreeKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);
            DimensionStructureNode searchForDSN = _scenarioContext[instance.SearchForObjectKey]
                as DimensionStructureNode;
            Check.IsNotNull(searchForDSN);
            DimensionStructureNode parent = _scenarioContext[instance.ParentKey] as DimensionStructureNode;
            Check.IsNotNull(parent);

            LookUpForDimensionStructureNodeAndParentResult result = await
                FindDimensionStructureNodeWithItsParentInTree(sourceFormat, searchForDSN)
                   .ConfigureAwait(false);

            result.Actual.Id.Should().Be(searchForDSN.Id);
            result.Parent.Id.Should().Be(parent.Id);
        }
    }
}