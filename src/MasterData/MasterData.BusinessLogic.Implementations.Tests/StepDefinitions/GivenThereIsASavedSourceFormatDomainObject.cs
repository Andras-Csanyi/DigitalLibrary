namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a saved SourceFormat domain object")]
        public async Task GivenThereIsASavedSourceFormatDomainObject(Table table)
        {
            GivenThereIsASavedSourceFormatDomainObjectEntity instance = table
               .CreateInstance<GivenThereIsASavedSourceFormatDomainObjectEntity>();

            ISourceFormatDomainObject domainObject = new ThereIsASourceFormatDomainObjectEntity
            {
                Name = instance.Name,
                Desc = instance.Desc,
                IsActive = instance.IsActive,
            };

            SourceFormat sourceFormat = _masterDataTestHelper
               .SourceFormatFactory
               .Create(domainObject);

            SourceFormat result = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    internal class GivenThereIsASavedSourceFormatDomainObjectEntity
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string ResultKey { get; set; }
    }
}