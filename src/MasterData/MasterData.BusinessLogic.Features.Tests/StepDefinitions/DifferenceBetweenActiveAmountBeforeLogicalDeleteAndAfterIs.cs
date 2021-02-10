namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"difference between lists is")]
        public void DifferenceBetweenActiveAmountBeforeLogicalDeleteAndAfterIs(Table table)
        {
            Check.IsNotNull(table);
            DifferenceBetweenActiveAmountBeforeLogicalDeleteAndAfterIsEntity instance =
                table.CreateInstance<DifferenceBetweenActiveAmountBeforeLogicalDeleteAndAfterIsEntity>();

            int amountBefore = (int) _scenarioContext[instance.FirstResultKey];
            int amountAfter = (int) _scenarioContext[instance.SecondResultKey];

            int result = amountBefore - amountAfter;
            result.Should().Be(instance.ExpectedDiff);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DifferenceBetweenActiveAmountBeforeLogicalDeleteAndAfterIsEntity
    {
        public int ExpectedDiff { get; set; }

        public string FirstResultKey { get; set; }

        public string SecondResultKey { get; set; }
    }
}