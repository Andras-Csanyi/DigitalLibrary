namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [Then(@"DimensionStructure related operation throws exception")]
        public void ExceptionWasThrown(Table table)
        {
            ExceptionWasThrownEntity instance = table.CreateInstance<ExceptionWasThrownEntity>();

            var exception = _scenarioContext[instance.ResultKey];
            exception.Should().BeOfType<MasterDataBusinessLogicDimensionStructureDatabaseOperationException>();
        }

        [Then(@"DimensionStructure tree contains given DimensionStructure")]
        public async Task ThenDimensionStructureTreeContainsGivenDimensionStructure(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(
                string sourceFormatKey,
                string ContainedDimensionStructureKey)>();

            SourceFormat sourceFormat = _scenarioContext[instance.sourceFormatKey] as SourceFormat;
            DimensionStructure dimensionStructure = _scenarioContext[instance.ContainedDimensionStructureKey]
                as DimensionStructure;

            SourceFormat withAllInvolvedNodes = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithAllDimensionStructuresAndNodesAsync(sourceFormat)
               .ConfigureAwait(false);

            withAllInvolvedNodes.DimensionStructureNodes
               .FirstOrDefault(c => c.DimensionStructure.Id == dimensionStructure.Id)
               .Should().NotBeNull();
        }

        [Then(@"given DimensionStructure is child of given DimensionStructure")]
        public async Task ThenGivenDimensionStructureIsChildOfGivenDimensionStructure(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(
                string sourceFormatKey,
                string parentKey,
                string childKey)>();

            SourceFormat sourceFormat = _scenarioContext[instance.sourceFormatKey] as SourceFormat;
            DimensionStructure parent = _scenarioContext[instance.parentKey] as DimensionStructure;
            DimensionStructure child = _scenarioContext[instance.childKey] as DimensionStructure;

            List<DimensionStructure> children = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
               .GetChildrenOfDimensionStructureInSourceFormatScopeAsync(
                    parent.Id,
                    sourceFormat.Id)
               .ConfigureAwait(false);

            children.FirstOrDefault(w => w.Id == child.Id)
               .Should().NotBeNull();
        }

        [Then(@"root DimensionStructure of '(.*)' SourceFormat is not null")]
        public void ThenRootDimensionStructureOfSourceFormatIsNotNull(string resultKey)
        {
            Check.NotNullOrEmptyOrWhitespace(resultKey);

            SourceFormat sourceFormat = _scenarioContext[resultKey] as SourceFormat;

            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode
               .Should().NotBeNull();
            sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode
               .DimensionStructure
               .Should().NotBeNull();
        }

        [Then(@"DimensionStructure amount is")]
        public void DimensionStructureAmountIs(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(int expectedAmount, string resultKey)>();

            List<DimensionStructure> list = _scenarioContext[instance.resultKey] as List<DimensionStructure>;
            list.Count.Should().Be(instance.expectedAmount);
        }

        [Then(@"list of DimensionStructure doesn't contain the deleted one")]
        public void ListOfDimensionStructureDoesntContainTheDeletedOne(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(string resultKey, string dimensionStructureKey)>();

            List<DimensionStructure> list = _scenarioContext[instance.resultKey] as List<DimensionStructure>;
            DimensionStructure dimensionStructure = _scenarioContext[instance.dimensionStructureKey]
                as DimensionStructure;

            list.Should().NotContain(dimensionStructure);
        }
    }
}