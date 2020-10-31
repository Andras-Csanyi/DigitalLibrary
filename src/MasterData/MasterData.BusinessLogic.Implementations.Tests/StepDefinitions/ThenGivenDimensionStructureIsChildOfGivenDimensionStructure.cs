namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;
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
        [Then(@"given DimensionStructure is child of given DimensionStructure")]
        public async Task ThenGivenDimensionStructureIsChildOfGivenDimensionStructure(Table table)
        {
            Check.IsNotNull(table);

            ThenGivenDimensionStructureIsChildOfGivenDimensionStructureEntity instance = table
               .CreateInstance<ThenGivenDimensionStructureIsChildOfGivenDimensionStructureEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DimensionStructure parent = _scenarioContext[instance.ParentKey] as DimensionStructure;
            Check.IsNotNull(parent);

            DimensionStructure child = _scenarioContext[instance.ChildKey] as DimensionStructure;
            Check.IsNotNull(child);

            List<DimensionStructure> children = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetChildrenOfDimensionStructureInSourceFormatScopeAsync(
                    parent.Id,
                    sourceFormat.Id)
               .ConfigureAwait(false);

            children.FirstOrDefault(w => w.Id == child.Id)
               .Should().NotBeNull();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ThenGivenDimensionStructureIsChildOfGivenDimensionStructureEntity
    {
        public string SourceFormatKey { get; set; }

        public string ParentKey { get; set; }

        public string ChildKey { get; set; }
    }
}