namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"SourceFormat don't have node with DimensionStructure")]
        [Then(@"SourceFormat don't have node with DimensionStructure")]
        public async Task SourceFormatHasInactiveNodeWithDimensionStructure(Table table)
        {
            SourceFormatHasInactiveNodeWithDimensionStructureEntity instance = table
               .CreateInstance<SourceFormatHasInactiveNodeWithDimensionStructureEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DimensionStructure dimensionStructure = _scenarioContext[instance.DimensionStructureKey]
                as DimensionStructure;
            Check.IsNotNull(dimensionStructure);

            DimensionStructureNode node = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetNodeAsync(sourceFormat.Id, dimensionStructure.Id)
               .ConfigureAwait(false);

            node.Should().BeNull();
        }
    }

    internal class SourceFormatHasInactiveNodeWithDimensionStructureEntity
    {
        public string DimensionStructureKey { get; set; }

        public string SourceFormatKey { get; set; }
    }
}