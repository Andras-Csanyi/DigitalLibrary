namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure related operation throws exception")]
        public void DimensionStructureRelatedOperationThrowsException(Table table)
        {
            KeyResultKeyEntity instance = table
               .CreateInstance<KeyResultKeyEntity>();

            var exception = _scenarioContext[instance.Key];
            exception.Should().BeOfType<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }
    }
}
