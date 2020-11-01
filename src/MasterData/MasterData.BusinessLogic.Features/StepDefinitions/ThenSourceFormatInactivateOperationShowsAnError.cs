namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat inactivate operation shows an error")]
        public void ThenSourceFormatInactivateOperationShowsAnError(Table table)
        {
            ThenSourceFormatInactivateOperationShowsAnErrorEntity instance = table
               .CreateInstance<ThenSourceFormatInactivateOperationShowsAnErrorEntity>();

            object ex = _scenarioContext[instance.Key];

            ex.GetType().Should().Be<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ThenSourceFormatInactivateOperationShowsAnErrorEntity
    {
        public string Key { get; set; }
    }
}