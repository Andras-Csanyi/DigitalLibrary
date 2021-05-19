namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure's node property equals to a number")]
        public void ThenDimensionStructuresNodePropertyEqualsToANumber(Table table)
        {
            KeyPropertyNameExpectedNumberValueEntity instance =
                table.CreateInstance<KeyPropertyNameExpectedNumberValueEntity>();

            DimensionStructureNode node = _scenarioContext[instance.Key] as DimensionStructureNode;
            string propertyName = instance.PropertyName;
            SourceFormat sourceFormat = _scenarioContext[instance.ExpectedResultReferenceSourceFormatKey]
                as SourceFormat;
            string sourceFormatPropertyName = instance.ReferencedSourceFormatPropertyName;

            long expectedValue = (long) sourceFormat
               .GetType()
               .GetProperty(sourceFormatPropertyName)
               .GetValue(sourceFormat, null);

            node.GetType().GetProperty(propertyName).GetValue(node, null)
               .Should()
               .Be(expectedValue);
        }
    }
}
