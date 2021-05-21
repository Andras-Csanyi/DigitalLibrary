namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a SourceFormatDimensionStructureNode domain object for validation")]
        public void GivenThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation(Table table)
        {
            ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation instance = table
               .CreateInstance<ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation>();

            SourceFormatDimensionStructureNode node = new SourceFormatDimensionStructureNode();

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

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThereIsASourceFormatDimensionStructureNodeDomainObjectForValidation
    {
        public string Id { get; set; }

        public string SourceFormatId { get; set; }

        public string DimensionStructureNodeId { get; set; }

        public string ResultKey { get; set; }
    }
}
