namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure's property is not empty")]
        public void ThenDimensionStructuresPropertyIsNotEmpty(Table table)
        {
            KeyPropertyNameEntity instance = table.CreateInstance<KeyPropertyNameEntity>();

            DimensionStructureNode node = _scenarioContext[instance.Key] as DimensionStructureNode;
            string propertyName = instance.PropertyName;

            node.GetType().GetProperty(propertyName).GetValue(node, null)
               .Should()
               .NotBeNull();
        }
    }
}
