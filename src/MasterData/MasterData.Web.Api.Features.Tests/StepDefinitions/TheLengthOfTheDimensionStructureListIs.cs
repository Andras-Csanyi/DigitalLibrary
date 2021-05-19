namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"the length of the DimensionStructure list is")]
        public void ThenTheLengthOfTheDimensionStructureListIs(Table table)
        {
            KeyExpectedLengthEntity instance = table.CreateInstance<KeyExpectedLengthEntity>();

            List<DimensionStructure> result = _scenarioContext[instance.Key] as List<DimensionStructure>;

            result.Count.Should().Be(instance.ExpectedLength);
        }
    }
}
