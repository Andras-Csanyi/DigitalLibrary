namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"list of DimensionStructure doesn't contain the deleted one")]
        public void ListOfDimensionStructureDoesntContainTheDeletedOne(Table table)
        {
            Check.IsNotNull(table);
            ListOfDimensionStructureDoesntContainTheDeletedOneEntity instance = table
               .CreateInstance<ListOfDimensionStructureDoesntContainTheDeletedOneEntity>();

            List<DimensionStructure> list = _scenarioContext[instance.ResultKey] as List<DimensionStructure>;
            Check.IsNotNull(list);

            DimensionStructure dimensionStructure = _scenarioContext[instance.DimensionStructureKey]
                as DimensionStructure;
            Check.IsNotNull(dimensionStructure);

            list.Should().NotContain(dimensionStructure);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ListOfDimensionStructureDoesntContainTheDeletedOneEntity
    {
        public string ResultKey { get; set; }

        public string DimensionStructureKey { get; set; }
    }
}
