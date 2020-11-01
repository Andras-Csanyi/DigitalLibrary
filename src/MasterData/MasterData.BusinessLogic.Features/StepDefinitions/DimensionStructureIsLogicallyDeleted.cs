namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"DimensionStructure is logically deleted")]
        public async Task DimensionStructureIsLogicallyDeleted(Table table)
        {
            Check.IsNotNull(table);
            DimensionStructureIsLogicallyDeletedEntity instance = table
               .CreateInstance<DimensionStructureIsLogicallyDeletedEntity>();

            DimensionStructure toBeDeleted = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(toBeDeleted);

            try
            {
                DimensionStructure dimensionStructure = new DimensionStructure
                {
                    Id = toBeDeleted.Id,
                };
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteLogicallyAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class DimensionStructureIsLogicallyDeletedEntity
    {
        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}