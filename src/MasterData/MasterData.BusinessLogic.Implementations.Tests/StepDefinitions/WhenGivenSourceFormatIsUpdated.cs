namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"given SourceFormat is updated")]
        [Given(@"given SourceFormat is updated")]
        public async Task WhenGivenSourceFormatIsUpdated(Table table)
        {
            WhenGivenSourceFormatIsUpdatedEntity instance = table
               .CreateInstance<WhenGivenSourceFormatIsUpdatedEntity>();

            SourceFormat payload = _scenarioContext[instance.Key] as SourceFormat;

            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .UpdateAsync(payload)
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
    internal class WhenGivenSourceFormatIsUpdatedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}