namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"operation result is")]
        [Then(@"operation result is")]
        public async Task OperationResultIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            string expectedResult = _scenarioContext[instance.Key] as string;
            Check.IsNotNull(expectedResult);

            expectedResult.Should().Be(instance.ExpectedValue);
        }
    }
}