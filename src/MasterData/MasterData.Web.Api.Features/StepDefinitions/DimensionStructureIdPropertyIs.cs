namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure Id property is")]
        public void ThenDimensionStructureIdPropertyIs(Table table)
        {
            KeyExpectedValueEntity instance = table.CreateInstance<KeyExpectedValueEntity>();

            DimensionStructure result = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(result);

            int exp = Convert.ToInt32(instance.ExpectedValue);
            result.IsActive.Should().Be(exp);
        }
    }
}