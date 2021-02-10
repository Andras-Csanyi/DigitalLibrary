namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result Id is changed")]
        public void GivenStoredSourceFormatResultIdIsChanged(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            result.Id = result.Id + 1000;
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}