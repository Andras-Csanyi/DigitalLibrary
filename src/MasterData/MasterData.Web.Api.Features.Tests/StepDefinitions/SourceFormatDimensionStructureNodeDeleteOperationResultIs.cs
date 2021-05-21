namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System;
    using System.Linq;

    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode delete operation result is")]
        public void ThenSourceFormatDimensionStructureNodeDeleteOperationResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            object result = _scenarioContext[instance.Key];

            string expectedValue = instance.ExpectedValue;
            bool areAllDigits = expectedValue.All(char.IsDigit);

            if (areAllDigits)
            {
                result.Should().Be(Convert.ToInt32(expectedValue));
            }
        }
    }
}
