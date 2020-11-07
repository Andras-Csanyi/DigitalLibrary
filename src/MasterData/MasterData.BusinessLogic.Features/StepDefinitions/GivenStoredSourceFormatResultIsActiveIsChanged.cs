namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result IsActive is changed")]
        public void GivenStoredSourceFormatResultIsActiveIsChanged(Table table)
        {
            GivenStoredSourceFormatResultIsActiveIsChangedEntity instance = table
               .CreateInstance<GivenStoredSourceFormatResultIsActiveIsChangedEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            sourceFormat.IsActive = instance.IsActive;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormat);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class GivenStoredSourceFormatResultIsActiveIsChangedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public int IsActive { get; set; }
    }
}