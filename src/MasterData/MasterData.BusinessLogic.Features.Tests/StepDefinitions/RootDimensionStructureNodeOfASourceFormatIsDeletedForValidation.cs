namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"RootDimensionStructureNode of a SourceFormat is deleted for validation")]
        public async Task RootDimensionStructureNodeOfASourceFormatIsDeletedForValidation(Table table)
        {
            RootDimensionStructureNodeOfASourceFormatIsDeletedEntity instance = table
               .CreateInstance<RootDimensionStructureNodeOfASourceFormatIsDeletedEntity>();

            string rootDimensionStructureNodeIdString = instance.RootDimensionStructureNodeKey;
            Check.NotNullOrEmptyOrWhitespace(rootDimensionStructureNodeIdString);
            int rootDimensionStructureNodeId = int.Parse(rootDimensionStructureNodeIdString);

            string sourceFormatIdString = instance.SourceFormatKey;
            Check.NotNullOrEmptyOrWhitespace(sourceFormatIdString);
            int sourceFormatId = int.Parse(sourceFormatIdString);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteRootDimensionStructureNodeAsync(rootDimensionStructureNodeId, sourceFormatId)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.OperationResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.OperationResultKey, FAIL);
            }
        }
    }
}
