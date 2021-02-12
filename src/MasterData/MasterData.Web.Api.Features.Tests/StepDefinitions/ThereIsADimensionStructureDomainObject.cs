namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a DimensionStructure domain object")]
        public void GivenThereIsADimensionStructureDomainObject(Table table)
        {
            ThereIsADimensionStructureDomainObjectEntity instance = table
               .CreateInstance<ThereIsADimensionStructureDomainObjectEntity>();

            DimensionStructure result = _masterDataTestHelper
               .DimensionStructureFactory
               .Create(instance);

            _scenarioContext.Add(instance.Key, result);
        }
    }
}