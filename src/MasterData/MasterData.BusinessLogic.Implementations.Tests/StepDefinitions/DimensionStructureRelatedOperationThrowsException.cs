namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure related operation throws exception")]
        public void DimensionStructureRelatedOperationThrowsException(Table table)
        {
            DimensionStructureRelatedOperationThrowsExceptionEntity instance = table
               .CreateInstance<DimensionStructureRelatedOperationThrowsExceptionEntity>();

            var exception = _scenarioContext[instance.ResultKey];
            exception.Should().BeOfType<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class DimensionStructureRelatedOperationThrowsExceptionEntity
    {
        public string ResultKey { get; set; }
    }
}