namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is in the tree in the database")]
        public async Task DimensionStructureNodeIsInTheTreeInTheDatabase(Table table)
        {
            DimensionStructureNodeKeySourceFormatKeyEntity instance = table
               .CreateInstance<DimensionStructureNodeKeySourceFormatKeyEntity>();

            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                as DimensionStructureNode;
            Check.IsNotNull(dimensionStructureNode);
            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdAndBySourceFormatId(dimensionStructureNode.Id, sourceFormat.Id)
               .ConfigureAwait(false);

            result.Should().NotBeNull();
        }
    }
}