namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is requested with root DimensionStructure")]
        public async Task SourceFormatIsRequestedWithRootDimensionStructure(Table table)
        {
            SourceFormatIsRequestedWithRootDimensionStructureEntity instance = table
               .CreateInstance<SourceFormatIsRequestedWithRootDimensionStructureEntity>();

            DomainModel.SourceFormat withoutTree = _scenarioContext[instance.Key] as SourceFormat;

            DomainModel.SourceFormat requestedWithTree = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureAsync(withoutTree)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, requestedWithTree);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class SourceFormatIsRequestedWithRootDimensionStructureEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}