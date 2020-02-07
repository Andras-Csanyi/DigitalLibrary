namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Utils.Guards;

    public class SourceFormatSelectorComponentComponentService : ISourceFormatSelectorComponentService
    {
        private readonly IMasterDataHttpClient _masterDataHttpClient;

        private readonly IMasterDataValidators _masterDataValidators;

        public SourceFormatSelectorComponentComponentService(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators)
        {
            Check.IsNotNull(masterDataHttpClient);
            Check.IsNotNull(masterDataValidators);

            _masterDataHttpClient = masterDataHttpClient;
            _masterDataValidators = masterDataValidators;
        }

        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            return await _masterDataHttpClient.GetSourceFormatsAsync().ConfigureAwait(false);
        }
    }

    public interface ISourceFormatSelectorComponentService
    {
        Task<List<SourceFormat>> GetSourceFormatsAsync();
    }
}