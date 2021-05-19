namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is not in the tree in the database")]
        public async Task DimensionStructureNodeIsNotInTheTreeInTheDatabase(Table table)
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

            result.Should().BeNull();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructureNodeKeySourceFormatKeyEntity
    {
        public string DimensionStructureNodeKey { get; set; }

        public string SourceFormatKey { get; set; }
    }
}
