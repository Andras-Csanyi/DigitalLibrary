namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructureNode parent in the database is")]
        public async Task DimensionStructureNodeParentInTheDatabaseIs(Table table)
        {
            DimensionStructureNodeParentInTheDatabaseIsEntity instance = table
               .CreateInstance<DimensionStructureNodeParentInTheDatabaseIsEntity>();

            DimensionStructureNode child = _scenarioContext[instance.ChildKey]
                as DimensionStructureNode;
            Check.IsNotNull(child);
            DimensionStructureNode parent = _scenarioContext[instance.ParentKey]
                as DimensionStructureNode;
            Check.IsNotNull(parent);

            DimensionStructureNode nodeWithParent = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetDimensionStructureNodeByIdWithParentAsync(child.Id)
               .ConfigureAwait(false);

            nodeWithParent.ParentNode.Id.Should().Be(parent.Id);
            nodeWithParent.ParentNodeId.Should().Be(parent.Id);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructureNodeParentInTheDatabaseIsEntity
    {
        public string ChildKey { get; set; }

        public string ParentKey { get; set; }
    }
}
