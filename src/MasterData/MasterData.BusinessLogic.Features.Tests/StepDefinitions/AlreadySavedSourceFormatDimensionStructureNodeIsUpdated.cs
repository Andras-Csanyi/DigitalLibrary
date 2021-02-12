namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [SuppressMessage("ReSharper", "PossibleNullReferenceException", Justification = "Covered.")]
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

            if (instance.Id != "none")
            {
                node.Id = Convert.ToInt32(instance.Id);
            }

            if (instance.SourceFormatId != "none")
            {
                node.SourceFormatId = Convert.ToInt32(instance.SourceFormatId);
            }

            if (instance.DimensionStructureNodeId != "none")
            {
                node.DimensionStructureNodeId = Convert.ToInt32(instance.DimensionStructureNodeId);
            }

            _scenarioContext.Add(instance.ResultKey, node);
        }
    }

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    internal class AlreadySavedSourceFormatDimensionStructureNodeIsUpdatedEntity
    {
        public string Id { get; set; }

        public string SourceFormatId { get; set; }

        public string DimensionStructureNodeId { get; set; }

        public string ResultKey { get; set; }

        public string Key { get; set; }
    }
}