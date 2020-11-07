namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
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

            if (string.IsNullOrEmpty(instance.Key) || string.IsNullOrWhiteSpace(instance.Key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _scenarioContext.Add(instance.Key, sourceFormat);
        }
    }
}