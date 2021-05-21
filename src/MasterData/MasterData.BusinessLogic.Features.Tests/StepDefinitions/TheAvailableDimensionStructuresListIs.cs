namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"the available DimensionStructures list with '(.*)' result key is (.*)")]
        public void ThenTheAvailableDimensionStructuresListIs(string resultKey, int expectedResult)
        {
            Check.NotNullOrEmptyOrWhitespace(resultKey);

            List<DimensionStructure> result = _scenarioContext[resultKey]
                as List<DimensionStructure>;
            Check.IsNotNull(result);

            result.Count.Should().Be(expectedResult);
        }
    }
}
