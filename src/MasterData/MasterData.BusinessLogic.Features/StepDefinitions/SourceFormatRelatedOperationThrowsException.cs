namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat related operation throws exception")]
        public void SourceFormatRelatedOperationThrowsException(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            var exception = _scenarioContext[instance.ResultKey];
            exception.Should().BeOfType<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}