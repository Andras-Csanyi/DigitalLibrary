namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormatDimensionStructureNode domain object for validation")]
        public void GivenThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation(Table table)
        {
            ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation instance = table
               .CreateInstance<ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation>();

            SourceFormat sourceFormat = null;
            DimensionStructureNode dimensionStructureNode = null;

            SourceFormatDimensionStructureNode node = new SourceFormatDimensionStructureNode();

            if (instance.Id != "none")
            {
                node.Id = Convert.ToInt32(instance.Id);
            }

            if (instance.SourceFormat != "null")
            {
                ISourceFormatDomainObject sourceFormatDomainObject = new SourceFormatDomainObjectEntity();

                sourceFormat = _masterDataTestHelper
                   .SourceFormatFactory
                   .Create(sourceFormatDomainObject);
                node.SourceFormat = sourceFormat;
            }

            if (instance.DimensionStructureNode != "null")
            {
                dimensionStructureNode = new DimensionStructureNode();
                node.DimensionStructureNode = dimensionStructureNode;
            }

            if (instance.SourceFormatId != instance.SourceFormat)
            {
                node.SourceFormatId = Convert.ToInt32(instance.SourceFormatId);
            }
            else
            {
                Check.IsNotNull(sourceFormat);
                node.SourceFormatId = sourceFormat.Id;
            }

            if (instance.DimensionStructureNodeId != instance.DimensionStructureNode)
            {
                node.DimensionStructureNodeId = Convert.ToInt32(instance.DimensionStructureNodeId);
            }
            else
            {
                Check.IsNotNull(dimensionStructureNode);
                node.DimensionStructureNodeId = dimensionStructureNode.Id;
            }

            _scenarioContext.Add(instance.ResultKey, node);
        }
    }

    internal class ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation
    {
        public string Id { get; set; }

        public string SourceFormatId { get; set; }

        public string SourceFormat { get; set; }

        public string DimensionStructureNodeId { get; set; }

        public string DimensionStructureNode { get; set; }

        public string ResultKey { get; set; }
    }
}