namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Linq;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"already saved SourceFormatDimensionStructureNode is updated")]
        public void GivenAlreadySavedSourceFormatDimensionStructureNodeIsUpdated(Table table)
        {
            AlreadySavedSourceFormatDimensionStructureNodeIsUpdatedEntity instance = table
               .CreateInstance<AlreadySavedSourceFormatDimensionStructureNodeIsUpdatedEntity>();

            SourceFormatDimensionStructureNode node = _scenarioContext[instance.Key]
                as SourceFormatDimensionStructureNode;
            Check.IsNotNull(node);

            SourceFormat sourceFormat = null;
            DimensionStructureNode dimensionStructureNode = null;

            if (instance.Id != "none")
            {
                node.Id = Convert.ToInt32(instance.Id);
            }

            if (instance.SourceFormat != "none")
            {
                sourceFormat = _scenarioContext[instance.SourceFormat] as SourceFormat;
                Check.IsNotNull(sourceFormat);
                node.SourceFormat = sourceFormat;
            }

            if (instance.SourceFormatId != "none")
            {
                bool isDigitsOnly = instance.SourceFormatId.All(char.IsDigit);
                if (isDigitsOnly)
                {
                    node.SourceFormatId = Convert.ToInt32(instance.SourceFormatId);
                }
                else
                {
                    SourceFormat sf = _scenarioContext[instance.SourceFormatId] as SourceFormat;
                    Check.IsNotNull(sf);
                    node.SourceFormatId = sf.Id;
                }
            }

            if (instance.DimensionStructureNode != "none")
            {
                dimensionStructureNode = _scenarioContext[instance.DimensionStructureNode]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                node.DimensionStructureNode = dimensionStructureNode;
            }

            if (instance.DimensionStructureNodeId != "none")
            {
                bool isDigitsOnly = instance.DimensionStructureNodeId.All(char.IsDigit);
                if (isDigitsOnly)
                {
                    node.DimensionStructureNodeId = Convert.ToInt32(instance.DimensionStructureNodeId);
                }
                else
                {
                    DimensionStructureNode dsn = _scenarioContext[instance.DimensionStructureNodeId]
                        as DimensionStructureNode;
                    Check.IsNotNull(dsn);
                    node.DimensionStructureNodeId = dsn.Id;
                }
            }

            _scenarioContext.Add(instance.ResultKey, node);
        }
    }

    internal class AlreadySavedSourceFormatDimensionStructureNodeIsUpdatedEntity
    {
        public string Id { get; set; }

        public string SourceFormatId { get; set; }

        public string SourceFormat { get; set; }

        public string DimensionStructureNodeId { get; set; }

        public string DimensionStructureNode { get; set; }

        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}