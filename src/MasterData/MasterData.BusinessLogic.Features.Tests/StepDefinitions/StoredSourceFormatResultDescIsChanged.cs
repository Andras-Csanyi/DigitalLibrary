namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result Desc is changed")]
        public void GivenStoredSourceFormatResultDescIsChanged(Table table)
        {
            GivenStoredSourceFormatResultDescIsChangedEntity instance = table
               .CreateInstance<GivenStoredSourceFormatResultDescIsChangedEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            sourceFormat.Desc = instance.Desc;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormat);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class GivenStoredSourceFormatResultDescIsChangedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string Desc { get; set; }
    }
}