namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure tree contains given DimensionStructure")]
        public async Task ThenDimensionStructureTreeContainsGivenDimensionStructure(Table table)
        {
            Check.IsNotNull(table);

            ThenDimensionStructureTreeContainsGivenDimensionStructureEntity instance = table
               .CreateInstance<ThenDimensionStructureTreeContainsGivenDimensionStructureEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            DimensionStructure dimensionStructure = _scenarioContext[instance.ContainedDimensionStructureKey]
                as DimensionStructure;

            SourceFormat withAllInvolvedNodes = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync(sourceFormat)
               .ConfigureAwait(false);

            withAllInvolvedNodes.DimensionStructureNodes
               .FirstOrDefault(c => c.DimensionStructure.Id == dimensionStructure.Id)
               .Should().NotBeNull();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThenDimensionStructureTreeContainsGivenDimensionStructureEntity
    {
        public string SourceFormatKey { get; set; }

        public string ContainedDimensionStructureKey { get; set; }
    }
}