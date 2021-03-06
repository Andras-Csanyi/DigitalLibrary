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
        [Then(@"DimensionStructure name property equals to")]
        public void ThenDimensionStructureNamePropertyEqualsTo(Table table)
        {
            KeyComparedToEntity instance = table.CreateInstance<KeyComparedToEntity>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(dimensionStructure);
            DimensionStructure comparedTo = _scenarioContext[instance.ComparedTo] as DimensionStructure;
            Check.IsNotNull(comparedTo);

            dimensionStructure.Name.Should().Be(comparedTo.Name);
        }
    }
}
