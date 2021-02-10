namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

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

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class GivenStoredSourceFormatResultNameIsChangedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string Name { get; set; }
    }
}