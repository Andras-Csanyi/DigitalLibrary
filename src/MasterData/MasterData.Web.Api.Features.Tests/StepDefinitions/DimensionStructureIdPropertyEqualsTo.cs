namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure Id property equals to")]
        public void ThenDimensionStructureIdPropertyEqualsTo(Table table)
        {
            KeyComparedToEntity instance = table.CreateInstance<KeyComparedToEntity>();

            DimensionStructure result = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(result);

            DimensionStructure comparedTo = _scenarioContext[instance.ComparedTo] as DimensionStructure;
            Check.IsNotNull(comparedTo);

            result.Id.Should().Be(comparedTo.Id);
        }
    }
}