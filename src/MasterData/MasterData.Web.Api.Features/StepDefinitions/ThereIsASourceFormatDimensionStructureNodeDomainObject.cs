namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormatDimensionStructureNode domain object")]
        public void GivenThereIsASourceFormatDimensionStructureNodeDomainObject(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormatDimensionStructureNode result = _masterDataTestHelper
               .SourceFormatDimensionStructureNodeFactory
               .Create(instance);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}