namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is added to DimensionStructure as child in tree of SourceFormat")]
        public async Task GivenDimensionStructureIsAddedToDimensionStructureAsChildInTreeOfSourceFormat(Table table)
        {
            GivenDimensionStructureIsAddedToDimensionStructureAsChildInTreeOfSourceFormatEntity instance = table
               .CreateInstance<GivenDimensionStructureIsAddedToDimensionStructureAsChildInTreeOfSourceFormatEntity>();

            DimensionStructure child = _scenarioContext[instance.ChildKey] as DimensionStructure;
            Check.IsNotNull(child);

            DimensionStructure parent = _scenarioContext[instance.ParentKey] as DimensionStructure;
            Check.IsNotNull(parent);

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddDimensionStructureToParentAsChildInSourceFormatAsync(child.Id, parent.Id, sourceFormat.Id)
               .ConfigureAwait(false);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class GivenDimensionStructureIsAddedToDimensionStructureAsChildInTreeOfSourceFormatEntity
    {
        public string ChildKey { get; set; }

        public string ParentKey { get; set; }

        public string SourceFormatKey { get; set; }

        [Then(@"asd asd asd asd")]
        public void ThenAsdAsdAsdAsd()
        {
            ScenarioContext.StepIsPending();
        }
    }
}