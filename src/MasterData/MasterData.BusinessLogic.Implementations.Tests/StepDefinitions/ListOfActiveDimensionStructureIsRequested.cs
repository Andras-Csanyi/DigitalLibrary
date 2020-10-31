namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
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
        [When(@"list of active DimensionStructures is requested")]
        public async Task ListOfActiveDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);
            ListOfActiveDimensionStructureIsRequestedEntity instance = table
               .CreateInstance<ListOfActiveDimensionStructureIsRequestedEntity>();

            List<DimensionStructure> result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetActivesAsync()
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ListOfActiveDimensionStructureIsRequestedEntity
    {
        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}