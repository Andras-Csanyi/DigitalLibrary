namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Net;

    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat domain object related '(.*)' save operation returns with bad request")]
        public void ThenSourceFormatDomainObjectRelatedSaveOperationReturnsWithBadRequest(string key)
        {
            Check.IsNotNull(key);

            int result = (int)_scenarioContext[key];

            result.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
