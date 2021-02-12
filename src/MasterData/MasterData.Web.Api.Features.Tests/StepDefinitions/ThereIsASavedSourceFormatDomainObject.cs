namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a saved SourceFormat domain object")]
        public async Task GivenThereIsASavedSourceFormatDomainObject(Table table)
        {
            ThereIsASavedSourceFormatDomainObjectEntity instance = table
               .CreateInstance<ThereIsASavedSourceFormatDomainObjectEntity>();

            SourceFormat sourceFormat = _masterDataTestHelper
               .SourceFormatFactory
               .Create(instance);

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .AddAsync(sourceFormat)
               .ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _scenarioContext.Add(instance.ResultKey, result.Result);
            }
        }
    }

    [ExcludeFromCodeCoverage]
    internal class ThereIsASavedSourceFormatDomainObjectEntity : ISourceFormatDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string ResultKey { get; set; }
    }
}