namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.BusinessLogic.Features.SpecflowEntities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormatDimensionStructureNode domain object")]
        public void GivenThereIsASourceFormatDimensionStructureNodeDomainObject(Table table)
        {
            SourceFormatDimensionStructureNodeDomainObjectEntity instance = table
               .CreateInstance<SourceFormatDimensionStructureNodeDomainObjectEntity>();

            SourceFormatDimensionStructureNode result = new SourceFormatDimensionStructureNode();

            if (instance.SourceFormatKey != null)
            {
                SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
                Check.IsNotNull(sourceFormat);
                result.SourceFormat = sourceFormat;
                result.SourceFormatId = sourceFormat.Id;
            }

            if (instance.DimensionStructureNodeKey != null)
            {
                DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                result.DimensionStructureNode = dimensionStructureNode;
                result.DimensionStructureNodeId = dimensionStructureNode.Id;
            }

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}