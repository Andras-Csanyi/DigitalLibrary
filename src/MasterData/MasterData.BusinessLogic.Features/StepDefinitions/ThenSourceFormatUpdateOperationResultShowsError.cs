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
        [Then(@"SourceFormat update operation result shows error")]
        public void ThenSourceFormatUpdateOperationResultShowsError(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            object result = _scenarioContext[instance.Key];

            result.GetType().Should().Be<MasterDataBusinessLogicSourceFormatDatabaseOperationException>();
        }
    }
}