namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Net;

    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat REST Delete method returns bad request")]
        public void ThenSourceFormatRESTDeleteMethodReturnsBadRequest(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            int statusCode = (int) _scenarioContext[instance.Key];

            statusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }
    }
}
