namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result Id is changed")]
        public void GivenStoredSourceFormatResultIdIsChanged(Table table)
        {
            GivenStoredSourceFormatResultIdIsChangedEntity instance = table
               .CreateInstance<GivenStoredSourceFormatResultIdIsChangedEntity>();

            SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            result.Id = result.Id + 1000;
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class GivenStoredSourceFormatResultIdIsChangedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }
    }
}