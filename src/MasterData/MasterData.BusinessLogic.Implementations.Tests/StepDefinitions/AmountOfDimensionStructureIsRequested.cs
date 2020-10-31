namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"amount of active DimensionStructure is requested")]
        public async Task AmountOfDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);
            AmountOfDimensionStructureIsRequestedEntity instance =
                table.CreateInstance<AmountOfDimensionStructureIsRequestedEntity>();

            int count = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetActiveCountAsync()
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, count);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class AmountOfDimensionStructureIsRequestedEntity
    {
        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}