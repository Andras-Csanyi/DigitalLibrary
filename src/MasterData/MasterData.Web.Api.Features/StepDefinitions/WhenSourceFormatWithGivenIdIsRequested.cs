namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"SourceFormat with given Id is requested")]
        public async Task WhenSourceFormatWithGivenIdIsRequested(Table table)
        {
            WhenSourceFormatWithGivenIdIsRequestedEntity instance = table
               .CreateInstance<WhenSourceFormatWithGivenIdIsRequestedEntity>();

            SourceFormat getById = _scenarioContext[instance.IdValueSource] as SourceFormat;
            Check.IsNotNull(getById);

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormat
               .GetByIdAsync(getById)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.Result);
        }
    }

    internal class WhenSourceFormatWithGivenIdIsRequestedEntity
    {
        public string IdValueSource { get; set; }

        public string ResultKey { get; set; }
    }
}