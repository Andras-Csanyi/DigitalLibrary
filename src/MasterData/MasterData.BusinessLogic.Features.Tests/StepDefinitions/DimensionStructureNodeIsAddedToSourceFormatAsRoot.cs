namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"DimensionStructureNode is added to SourceFormat as root")]
        public async Task DimensionStructureNodeIsAddedToSourceFormatAsRoot(Table table)
        {
            DimensionStructureNodeIsAddedToSourceFormatAsRootEntity instance =
                table.CreateInstance<DimensionStructureNodeIsAddedToSourceFormatAsRootEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey]
                as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                as DimensionStructureNode;
            Check.IsNotNull(dimensionStructureNode);

            try
            {
                await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .AddRootDimensionStructureNodeAsync(sourceFormat.Id, dimensionStructureNode.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }
}