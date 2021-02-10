namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;

    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormatDimensionStructureNode delete operation result is an exception")]
        public void ThenSourceFormatDimensionStructureNodeDeleteOperationResultIsAnException(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            Object result = _scenarioContext[instance.Key];
            Check.IsNotNull(result);

            result.GetType().Should().BeDerivedFrom<Exception>();
        }
    }
}