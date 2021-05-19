namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System;

    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"operation result is")]
        public void ThenOperationResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            int result = (int) _scenarioContext[instance.Key];

            int expected = Convert.ToInt32(instance.ExpectedValue);
            result.Should().Be(expected);
        }
    }
}
