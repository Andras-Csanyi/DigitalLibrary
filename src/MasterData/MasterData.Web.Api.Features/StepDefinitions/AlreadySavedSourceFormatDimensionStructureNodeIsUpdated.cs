namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

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

            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                _scenarioContext[instance.Key] as SourceFormatDimensionStructureNode;
            Check.IsNotNull(sourceFormatDimensionStructureNode);

            if (instance.Id != "none")
            {
                sourceFormatDimensionStructureNode.Id = Convert.ToInt32(instance.Id);
            }

            if (instance.SourceFormatId != "none")
            {
                sourceFormatDimensionStructureNode.SourceFormatId = Convert.ToInt32(instance.SourceFormatId);
            }

            if (instance.DimensionStructureNodeId != "none")
            {
                sourceFormatDimensionStructureNode.DimensionStructureNodeId = Convert
                   .ToInt32(instance.DimensionStructureNodeId);
            }

            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, sourceFormatDimensionStructureNode);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class AlreadySavedSourceFormatDimensionStructureNodeIsUpdatedEntity
    {
        public string Key { get; set; }

        public string ResultKey { get; set; }

        public string Id { get; set; }

        public string SourceFormatId { get; set; }

        public string DimensionStructureNodeId { get; set; }
    }
}