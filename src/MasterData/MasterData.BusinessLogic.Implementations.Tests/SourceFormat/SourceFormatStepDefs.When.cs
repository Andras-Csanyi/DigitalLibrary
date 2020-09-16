namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System.Threading.Tasks;

    using TechTalk.SpecFlow;

    public partial class SourceFormatStepDefs
    {
        [When(@"saving SourceFormat")]
        public async Task SavingSourceFormat()
        {
            
        }

        [When(@"it returns with the newly added SourceFormat")]
        public async Task ItReturnsWithTheNewlyAddedSourceFormat()
        {
            _sourceFormatResult = await _masterDataBusinessLogic.AddSourceFormatAsync(_sourceFormat)
               .ConfigureAwait(false);
        }
        
        
    }
}