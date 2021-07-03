namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"it returns")]
        public void ItReturns(Table table)
        {
            var instance = table.CreateInstance<StatusCodeEntity>();
            DilibHttpClientResponse<SourceFormat> webApiRequestResult =
                GetKeyValueFromScenarioContext<DilibHttpClientResponse<SourceFormat>>(ScenarioContextKeys
                   .WebApiCallResult);

            int statusCode = int.Parse(instance.StatusCode);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class StatusCodeEntity
    {
        public string StatusCode { get; set; }
    }
}
