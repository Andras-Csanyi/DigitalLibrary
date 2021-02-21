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
        [When(@"DimensionStructureNode is added to the tree of a SourceFormat")]
        public async Task WhenDimensionStructureNodeIsAddedToTheTReeOfASourceFormat(Table table)
        {
            DimensionStructureNodeIsAddedToTreeOfASourceFormatEntity instance =
                table.CreateInstance<DimensionStructureNodeIsAddedToTreeOfASourceFormatEntity>();

            SourceFormat sourceFormat = GetValueFromScenarioContext<SourceFormat>(
                instance.SourceFormatKey,
                _scenarioContext);
            Check.IsNotNull(sourceFormat);

            DimensionStructureNode toBeAddedDimensionStructureNode =
                GetValueFromScenarioContext<DimensionStructureNode>(
                    instance.ToBeAddedDimensionStructureNodeKey,
                    _scenarioContext);
            Check.IsNotNull(toBeAddedDimensionStructureNode);

            DimensionStructureNode parentDimensionStructureNode = GetValueFromScenarioContext<DimensionStructureNode>(
                instance.ParentDimensionStructureNodeKey,
                _scenarioContext);
            Check.IsNotNull(parentDimensionStructureNode);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AppendDimensionStructureNodeToTreeAsync(
                        toBeAddedDimensionStructureNode.Id,
                        parentDimensionStructureNode.Id,
                        sourceFormat.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.OperationResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.OperationResultKey, e);
            }
        }
    }
}