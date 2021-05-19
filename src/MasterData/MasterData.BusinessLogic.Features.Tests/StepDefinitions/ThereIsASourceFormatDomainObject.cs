namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormat domain object")]
        public void GivenThereIsASourceFormatDomainObject(Table table)
        {
            GivenThereIsASourceFormatDomainObjectEntity instance = table
               .CreateInstance<GivenThereIsASourceFormatDomainObjectEntity>();

            DomainModel.SourceFormat sourceFormat = _masterDataTestHelper
               .SourceFormatFactory
               .Create(instance);

            _scenarioContext.Add(instance.Key, sourceFormat);
        }
    }
}
