namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result Name is changed")]
        public void GivenStoredSourceFormatResultNameIsChanged(Table table)
        {
            GivenStoredSourceFormatResultNameIsChangedEntity instance = table
               .CreateInstance<GivenStoredSourceFormatResultNameIsChangedEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            sourceFormat.Name = instance.Name;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormat);
        }
    }

    internal class GivenStoredSourceFormatResultNameIsChangedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string Name { get; set; }
    }
}