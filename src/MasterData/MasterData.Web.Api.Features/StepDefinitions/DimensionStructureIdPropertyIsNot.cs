namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure Id property is not")]
        public void ThenDimensionStructureIdPropertyIsNot(Table table)
        {
            ThenDimensionStructureIdPropertyIsNotEntity instance = table
               .CreateInstance<ThenDimensionStructureIdPropertyIsNotEntity>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(dimensionStructure);

            dimensionStructure.Id.Should().NotBe(instance.NotEqualsTo);
        }
    }

    internal class ThenDimensionStructureIdPropertyIsNotEntity
    {
        public string Key { get; set; }

        public int NotEqualsTo { get; set; }
    }
}