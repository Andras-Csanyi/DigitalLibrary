namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored SourceFormat result Id set to")]
        public void GivenStoredSourceFormatResultIdSetTo(Table table)
        {
            GivenStoredSourceFormatResultIdSetToEntity instance = table
               .CreateInstance<GivenStoredSourceFormatResultIdSetToEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.ResultKey] as SourceFormat;
            sourceFormat.Id = instance.Id;
            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormat);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class GivenStoredSourceFormatResultIdSetToEntity
    {
        public string ResultKey { get; set; }

        public int Id { get; set; }
    }
}