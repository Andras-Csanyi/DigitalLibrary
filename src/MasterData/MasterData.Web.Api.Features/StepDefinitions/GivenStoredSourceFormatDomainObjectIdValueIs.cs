namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

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

            SourceFormat source = _scenarioContext[instance.IdValueSource] as SourceFormat;
            Check.IsNotNull(source);

            SourceFormat modified = _scenarioContext[instance.Key]
                as SourceFormat;
            Check.IsNotNull(modified);

            modified.Id = source.Id;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, modified);
        }
    }

    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class GivenStoredSourceFormatDomainObjectIdValueIsEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string IdValueSource { get; set; }
    }
}