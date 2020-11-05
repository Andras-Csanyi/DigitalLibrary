namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Net;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api.Client.Exceptions;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat domain object related '(.*)' save operation returns with bad request")]
        public void ThenSourceFormatDomainObjectRelatedSaveOperationReturnsWithBadRequest(string key)
        {
            Check.IsNotNull(key);

            DilibHttpClientResponse<SourceFormat> res = _scenarioContext[key]
                as DilibHttpClientResponse<SourceFormat>;
            int result = (int) res.HttpStatusCode;

            result.Should().Be((int) HttpStatusCode.BadRequest);
        }
    }
}