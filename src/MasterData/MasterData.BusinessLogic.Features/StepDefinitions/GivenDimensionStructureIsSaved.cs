namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is saved")]
        [When(@"DimensionStructure is saved")]
        public async Task GivenDimensionStructureIsSaved(Table table)
        {
            Check.IsNotNull(table);

            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

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
}