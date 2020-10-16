namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System.Collections.Generic;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [Then(@"difference between list is")]
        public void DifferenceBetweenActiveAmountBeforeLogicalDeleteAndAfterIs(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(int expectedDiff,
                string firstResultKey,
                string secondResultKey)>();

            int amountBefore = (int) _scenarioContext[instance.firstResultKey];
            int amountAfter = (int) _scenarioContext[instance.secondResultKey];

            int result = amountBefore - amountAfter;
            result.Should().Be(instance.expectedDiff);
        }
    }
}