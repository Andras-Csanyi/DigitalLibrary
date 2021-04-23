namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode is requested and result is")]
        public async Task DimensionStructureNodeIsRequestedAndResultIs(Table table)
        {
            KeyResultKeyExpectedResultEntity instance = table
               .CreateInstance<KeyResultKeyExpectedResultEntity>();

            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.Key]
                as DimensionStructureNode;
            Check.IsNotNull(dimensionStructureNode);

            DimensionStructureNode result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeById(dimensionStructureNode.Id)
               .ConfigureAwait(false);

            switch (instance.ExpectedResult.ToLower())
            {
                case ExpectedResultOptions.Null:
                    result.Should().BeNull();
                    break;

                default:
                    throw new Exception("Error.");
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class KeyResultKeyExpectedResultEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string ExpectedResult { get; set; }
    }
}