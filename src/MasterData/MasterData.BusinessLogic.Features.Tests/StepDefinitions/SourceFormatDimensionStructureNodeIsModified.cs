namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"SourceFormatDimensionStructureNode is modified")]
        public void GivenSourceFormatDimensionStructureNodeIsModified(Table table)
        {
            SourceFormatDimensionStructureNodeIsModifiedEntity instance = table
               .CreateInstance<SourceFormatDimensionStructureNodeIsModifiedEntity>();

            SourceFormatDimensionStructureNode node = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(node);

            if (instance.SourceFormatKey != null)
            {
                SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
                Check.IsNotNull(sourceFormat);
                node.SourceFormat = sourceFormat;
                node.SourceFormatId = sourceFormat.Id;
            }

            if (instance.DimensionStructureNodeKey != null)
            {
                DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeKey]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                node.DimensionStructureNode = dimensionStructureNode;
                node.DimensionStructureNodeId = dimensionStructureNode.Id;
            }

            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, node);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class SourceFormatDimensionStructureNodeIsModifiedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string DimensionStructureNodeKey { get; set; }
    }
}