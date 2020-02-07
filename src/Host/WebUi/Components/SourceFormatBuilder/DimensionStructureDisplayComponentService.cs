namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Utils.Guards;

    public class DimensionStructureDisplayComponentComponentService : IDimensionStructureDisplayComponentService
    {
        private readonly IMasterDataHttpClient _masterDataHttpClient;

        private readonly IMasterDataValidators _masterDataValidators;

        public DimensionStructureDisplayComponentComponentService(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators)
        {
            Check.IsNotNull(masterDataHttpClient);
            Check.IsNotNull(masterDataValidators);

            _masterDataHttpClient = masterDataHttpClient;
            _masterDataValidators = masterDataValidators;
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            return await _masterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }
    }

    public interface IDimensionStructureDisplayComponentService
    {
        Task<List<DimensionStructure>> GetDimensionStructuresAsync();
    }
}