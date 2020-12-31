namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
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
        [Then(@"difference between two DimensionLists")]
        public void ThenDifferenceBetweenTwoDimensionLists(Table table)
        {
            ThenDifferenceBetweenTwoDimensionListsEntity instance = table
               .CreateInstance<ThenDifferenceBetweenTwoDimensionListsEntity>();

            List<DimensionStructure> beforeList = _scenarioContext[instance.BeforeKey]
                as List<DimensionStructure>;
            Check.IsNotNull(beforeList);

            List<DimensionStructure> afterList = _scenarioContext[instance.AfterKey]
                as List<DimensionStructure>;
            Check.IsNotNull(afterList);

            beforeList.Count.Should().Be(afterList.Count + 1);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class ThenDifferenceBetweenTwoDimensionListsEntity
    {
        public string BeforeKey { get; set; }

        public string AfterKey { get; set; }
    }
}