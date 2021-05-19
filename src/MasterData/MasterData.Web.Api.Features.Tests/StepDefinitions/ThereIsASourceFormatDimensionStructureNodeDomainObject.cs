namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormatDimensionStructureNode domain object")]
        public void GivenThereIsASourceFormatDimensionStructureNodeDomainObject(Table table)
        {
            ThereIsASourceFormatDimensionStructureNodeDomainObjectEntity instance = table
               .CreateInstance<ThereIsASourceFormatDimensionStructureNodeDomainObjectEntity>();

            SourceFormatDimensionStructureNode result = new SourceFormatDimensionStructureNode();

            if (instance.SourceFormatKey != null)
            {
                SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey]
                    as SourceFormat;
                Check.IsNotNull(sourceFormat);
                result.SourceFormatId = sourceFormat.Id;
                result.SourceFormat = sourceFormat;
            }

            if (instance.DimensionStructureNodeKey != null)
            {
                DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                result.DimensionStructureNodeId = dimensionStructureNode.Id;
                result.DimensionStructureNode = dimensionStructureNode;
            }

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }
}
