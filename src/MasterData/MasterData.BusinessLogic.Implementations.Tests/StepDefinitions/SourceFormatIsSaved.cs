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
        [Given(@"SourceFormat is saved")]
        [When(@"SourceFormat is saved")]
        public async Task SourceFormatIsSaved(Table table)
        {
            SourceFormatIsSavedEntity instance = table.CreateInstance<SourceFormatIsSavedEntity>();

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

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class SourceFormatIsSavedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}