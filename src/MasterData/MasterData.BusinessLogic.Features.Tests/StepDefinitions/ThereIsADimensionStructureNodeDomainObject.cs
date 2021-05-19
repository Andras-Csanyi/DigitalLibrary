namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a DimensionStructureNode domain object")]
        public void ThereIsADimensionStructureNodeDomainObject(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DimensionStructureNode dimensionStructureNode = new DimensionStructureNode();

            _scenarioContext.Add(instance.ResultKey, dimensionStructureNode);
        }
    }
}
