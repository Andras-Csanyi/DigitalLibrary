namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"list of DimensionStructures is requested")]
        public async Task ListOfDimensionStructuresIsRequested(Table table)
        {
            Check.IsNotNull(table);
            ListOfDimensionStructuresIsRequestedEntity instance = table
               .CreateInstance<ListOfDimensionStructuresIsRequestedEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructuresAsync()
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ListOfDimensionStructuresIsRequestedEntity
    {
        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}