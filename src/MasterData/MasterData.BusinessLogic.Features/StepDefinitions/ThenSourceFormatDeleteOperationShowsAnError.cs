namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat delete operation shows an error")]
        public void ThenSourceFormatDeleteOperationShowsAnError(Table table)
        {
            ThenSourceFormatDeleteOperationShowsAnErrorEntity instance = table
               .CreateInstance<ThenSourceFormatDeleteOperationShowsAnErrorEntity>();

            object result = _scenarioContext[instance.Key];

            result.GetType().Should().Be<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ThenSourceFormatDeleteOperationShowsAnErrorEntity
    {
        public string Key { get; set; }
    }
}