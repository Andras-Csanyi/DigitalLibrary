namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Gherkin.Events.Args.Attachment;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat is queried by id")]
        public async Task WhenSourceFormatIsQueriedById(Table table)
        {
            WhenSourceFormatIsQueriedByIdEntity instance = table
               .CreateInstance<WhenSourceFormatIsQueriedByIdEntity>();

            SourceFormat before = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(before);

            SourceFormat byId = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetByIdAsync(before)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, byId);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class WhenSourceFormatIsQueriedByIdEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}