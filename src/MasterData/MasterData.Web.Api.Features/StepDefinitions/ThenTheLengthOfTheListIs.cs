namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"the length of the list is")]
        public void ThenTheLengthOfTheListIs(Table table)
        {
            ThenTheLengthOfTheListIsEntity instance = table.CreateInstance<ThenTheLengthOfTheListIsEntity>();

            List<SourceFormat> result = _scenarioContext[instance.Key] as List<SourceFormat>;

            result.Count.Should().Be(instance.ExpectedAmount);
        }
    }

    internal class ThenTheLengthOfTheListIsEntity
    {
        public string Key { get; set; }

        public int ExpectedAmount { get; set; }
    }
}