namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"it returns")]
        public void ItReturns(Table table)
        {
            var instance = table.CreateInstance<StatusCodeEntity>();
            DilibHttpClientResponse<SourceFormat> result =
                GetKeyValueFromScenarioContext<DilibHttpClientResponse<SourceFormat>>(instance.ResultKey);

            int expectedStatusCode = int.Parse(instance.StatusCode);
            result.HttpStatusCode.Should().Be(expectedStatusCode);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class StatusCodeEntity
    {
        public string StatusCode { get; set; }

        public string ResultKey { get; set; }
    }
}
