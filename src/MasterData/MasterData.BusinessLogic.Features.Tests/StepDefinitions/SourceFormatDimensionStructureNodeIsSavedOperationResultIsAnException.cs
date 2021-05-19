namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;

    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode is saved operation result is an exception")]
        public void ThenSourceFormatDimensionStructureNodeIsSavedOperationResultIsAnException(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            Object result = _scenarioContext[instance.Key];

            result.GetType().Should().BeDerivedFrom<Exception>();
        }
    }
}
