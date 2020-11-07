namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"I have saved SourceFormats in the system")]
        public async Task GivenIHaveSavedSourceFormatsInTheSystem(Table table)
        {
            GivenIHaveSavedSourceFormatsInTheSystemEntity instance = table
               .CreateInstance<GivenIHaveSavedSourceFormatsInTheSystemEntity>();

            for (int i = 0; i < instance.Amount; i++)
            {
                SourceFormat sourceFormat = _masterDataTestHelper
                   .SourceFormatFactory
                   .Create(instance);

                await _masterDataHttpClient
                   .SourceFormat
                   .AddAsync(sourceFormat)
                   .ConfigureAwait(false);
            }
        }
    }

    internal class GivenIHaveSavedSourceFormatsInTheSystemEntity : ISourceFormatDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }
    }
}