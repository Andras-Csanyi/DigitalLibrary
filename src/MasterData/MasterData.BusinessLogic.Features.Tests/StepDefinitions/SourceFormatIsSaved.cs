namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"SourceFormat is saved")]
        [When(@"SourceFormat is saved")]
        public async Task SourceFormatIsSaved(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            DomainModel.SourceFormat toBeSaved = _scenarioContext[instance.Key] as SourceFormat;
            try
            {
                SourceFormat saved = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddAsync(toBeSaved)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, saved);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}