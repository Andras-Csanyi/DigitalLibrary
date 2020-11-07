namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat domain object Id value is set to")]
        public void GivenStoredSourceFormatDomainObjectIdValueIsSetTo(Table table)
        {
            GivenStoredSourceFormatDomainObjectIdValueIsSetTo instance = table
               .CreateInstance<GivenStoredSourceFormatDomainObjectIdValueIsSetTo>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;

            sourceFormat.Id = instance.NewValue;

            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormat);
        }
    }

    internal class GivenStoredSourceFormatDomainObjectIdValueIsSetTo
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public int NewValue { get; set; }
    }
}