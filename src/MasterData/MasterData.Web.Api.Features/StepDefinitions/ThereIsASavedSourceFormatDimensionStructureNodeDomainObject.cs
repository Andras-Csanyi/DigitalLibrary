namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a saved SourceFormatDimensionStructureNode domain object")]
        public void GivenThereIsASavedSourceFormatDimensionStructureNodeDomainObject(Table table)
        {
            ThereIsASavedSourceFormatDimensionStructureNodeDomainObjectEntity instance = table
               .CreateInstance<ThereIsASavedSourceFormatDimensionStructureNodeDomainObjectEntity>();

            SourceFormatDimensionStructureNode node = new SourceFormatDimensionStructureNode();

            if (instance.SourceFormatKey != null)
            {
                SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
                Check.IsNotNull(sourceFormat);
                node.SourceFormatId = sourceFormat.Id;
            }

            if (instance.DimensionStructureNodeKey != null)
            {
                DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                node.DimensionStructureNodeId = dimensionStructureNode.Id;
            }

            _scenarioContext.Add(instance.ResultKey, node);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class ThereIsASavedSourceFormatDimensionStructureNodeDomainObjectEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string DimensionStructureNodeKey { get; set; }
    }
}