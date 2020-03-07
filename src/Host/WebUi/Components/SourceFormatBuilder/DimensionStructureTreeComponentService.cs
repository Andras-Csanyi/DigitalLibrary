namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Utils.Guards;

    public class DimensionStructureTreeComponentService : IDimensionStructureTreeComponentService
    {
        private readonly IMasterDataHttpClient _masterDataHttpClient;

        private readonly IMasterDataValidators _masterDataValidators;

        public DimensionStructureTreeComponentService(
            IMasterDataHttpClient masterDataHttpClient,
            IMasterDataValidators masterDataValidators)
        {
            Check.IsNotNull(masterDataHttpClient);
            Check.IsNotNull(masterDataValidators);

            _masterDataHttpClient = masterDataHttpClient;
            _masterDataValidators = masterDataValidators;
        }

        public async Task<DimensionStructure> GetDimensionStructureById(DimensionStructure queryDimensionStructure)
        {
            return await _masterDataHttpClient.GetDimensionStructureByIdAsync(queryDimensionStructure)
               .ConfigureAwait(false);
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            return await _masterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }
    }

    public interface IDimensionStructureTreeComponentService
    {
        Task<DimensionStructure> GetDimensionStructureById(DimensionStructure queryDimensionStructure);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();
    }
}