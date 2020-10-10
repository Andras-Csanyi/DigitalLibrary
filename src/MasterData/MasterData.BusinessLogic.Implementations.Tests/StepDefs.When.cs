namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    public partial class StepDefs
    {
        [When(@"SourceFormat is requested with DimensionStructure tree")]
        public async Task SourceFormatIsRequestedWithDimensionStructureTree(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            DomainModel.SourceFormat withoutTree = _scenarioContext[instance.key] as SourceFormat;

            DomainModel.SourceFormat requestedWithTree = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(withoutTree)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.resultKey, requestedWithTree);
        }

        [When(@"DimensionStructure is requested")]
        public async Task GivenDimensionStructureIsRequested(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(string key, string resultKey)>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.key] as DimensionStructure;

            DimensionStructure dimensionStructureResult = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructureByIdAsync(dimensionStructure)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.resultKey, dimensionStructureResult);
        }
    }
}