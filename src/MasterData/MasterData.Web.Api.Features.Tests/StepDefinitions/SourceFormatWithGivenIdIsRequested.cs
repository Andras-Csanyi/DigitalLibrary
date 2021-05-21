namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
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
               .SourceFormatHttpClient
               .GetByIdAsync(getById)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result.Result);
        }
    }

    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class WhenSourceFormatWithGivenIdIsRequestedEntity
    {
        public string IdValueSource { get; set; }

        public string ResultKey { get; set; }
    }
}
