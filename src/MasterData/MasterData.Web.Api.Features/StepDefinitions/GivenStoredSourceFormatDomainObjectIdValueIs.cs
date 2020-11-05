namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using Gherkin.Events.Args.Attachment;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat domain object Id value is")]
        public void GivenStoredSourceFormatDomainObjectIdValueIs(Table table)
        {
            GivenStoredSourceFormatDomainObjectIdValueIsEntity instance = table
               .CreateInstance<GivenStoredSourceFormatDomainObjectIdValueIsEntity>();

            DilibHttpClientResponse<SourceFormat> source = _scenarioContext[instance.IdValueSource]
                as DilibHttpClientResponse<SourceFormat>;
            Check.IsNotNull(source);

            SourceFormat modified = _scenarioContext[instance.Key]
                as SourceFormat;
            Check.IsNotNull(modified);

            modified.Id = source.Result.Id;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, modified);
        }
    }

    internal class GivenStoredSourceFormatDomainObjectIdValueIsEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string IdValueSource { get; set; }
    }
}