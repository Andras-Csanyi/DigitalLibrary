namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using DigitalLibrary.MasterData.Web.Api.Client.Exceptions;
    using DigitalLibrary.Utils.Guards;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat domain object related '(.*)' save operation returns with bad request")]
        public void ThenSourceFormatDomainObjectRelatedSaveOperationReturnsWithBadRequest(string key)
        {
            Check.IsNotNull(key);
            object result = _scenarioContext[key];

            result.GetType().Should().Be<MasterDataHttpClientException>();
        }
    }
}