namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat delete operation doesn't show error")]
        public void ThenSourceFormatDeleteOperationDoesntShowError(Table table)
        {
            ThenSourceFormatDeleteOperationDoesntShowErrorEntity instance = table
               .CreateInstance<ThenSourceFormatDeleteOperationDoesntShowErrorEntity>();

            string result = _scenarioContext[instance.Key] as string;
            result.Should().Be(SUCCESS);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class ThenSourceFormatDeleteOperationDoesntShowErrorEntity
    {
        public string Key { get; set; }
    }
}