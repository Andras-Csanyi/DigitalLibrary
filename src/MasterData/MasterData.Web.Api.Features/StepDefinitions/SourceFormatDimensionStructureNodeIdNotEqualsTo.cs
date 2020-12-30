namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode id not equals to")]
        public void ThenSourceFormatDimensionStructureNodeIdNotEqualsTo(Table table)
        {
            KeyNotEqualsToEntityLong instance = table.CreateInstance<KeyNotEqualsToEntityLong>();

            SourceFormatDimensionStructureNode result = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(result);

            result.Id.Should().NotBe(instance.NotEqualsToLong);
        }
    }
}