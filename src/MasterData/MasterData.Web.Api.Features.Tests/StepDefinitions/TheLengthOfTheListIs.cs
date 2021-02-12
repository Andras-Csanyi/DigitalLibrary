namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"the length of the list is")]
        public void ThenTheLengthOfTheListIs(Table table)
        {
            ThenTheLengthOfTheListIsEntity instance = table.CreateInstance<ThenTheLengthOfTheListIsEntity>();

            List<SourceFormat> result = _scenarioContext[instance.Key] as List<SourceFormat>;

            result.Count.Should().Be(instance.ExpectedAmount);
        }
    }

    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThenTheLengthOfTheListIsEntity
    {
        public string Key { get; set; }

        public int ExpectedAmount { get; set; }
    }
}