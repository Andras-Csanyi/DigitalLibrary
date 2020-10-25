namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"the length of the SourceFormats list in '(.*)' is (.*)")]
        public void ThenTheLengthOfTheSourceFormatsListInIs(string resultKey, int expectedLength)
        {
            List<SourceFormat> list = _scenarioContext[resultKey] as List<SourceFormat>;
            Check.IsNotNull(list);
            list.Count.Should().Be(expectedLength);
        }
    }
}