namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
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
        [Given(@"DimensionStructure is saved")]
        [When(@"DimensionStructure is saved")]
        public async Task GivenDimensionStructureIsSaved(Table table)
        {
            Check.IsNotNull(table);

            GivenDimensionStructureIsSavedEntity instance = table
               .CreateInstance<GivenDimensionStructureIsSavedEntity>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(dimensionStructure);

            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class GivenDimensionStructureIsSavedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}