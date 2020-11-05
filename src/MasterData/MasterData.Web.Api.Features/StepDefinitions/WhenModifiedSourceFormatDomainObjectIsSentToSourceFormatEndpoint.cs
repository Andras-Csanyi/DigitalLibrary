namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"modified SourceFormat domain object is sent to SourceFormat endpoint")]
        public async Task WhenModifiedSourceFormatDomainObjectIsSentToSourceFormatEndpoint(Table table)
        {
            Check.IsNotNull(table);
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat sourceFormat = _scenarioContext[instance.Key] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormat
               .UpdateAsync(sourceFormat)
               .ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _scenarioContext.Add(instance.ResultKey, result.Result);
            }
            else
            {
                _scenarioContext.Add(instance.ResultKey, result.HttpStatusCode);
            }
        }
    }
}