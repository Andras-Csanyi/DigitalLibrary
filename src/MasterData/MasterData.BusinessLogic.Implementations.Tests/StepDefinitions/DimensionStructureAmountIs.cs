namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure amount is")]
        public void DimensionStructureAmountIs(Table table)
        {
            Check.IsNotNull(table);
            DimensionStructureAmountIsEntity instance = table.CreateInstance<DimensionStructureAmountIsEntity>();

            List<DimensionStructure> list = _scenarioContext[instance.ResultKey] as List<DimensionStructure>;
            Check.IsNotNull(list);

            list.Count.Should().Be(instance.ExpectedAmount);
        }
    }

    internal class DimensionStructureAmountIsEntity
    {
        public int ExpectedAmount { get; set; }

        public string ResultKey { get; set; }
    }
}