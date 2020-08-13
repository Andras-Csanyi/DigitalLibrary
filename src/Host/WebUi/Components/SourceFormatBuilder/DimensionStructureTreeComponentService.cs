// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
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

        public async Task<DimensionStructure> GetDimensionStructureById(DimensionStructureQueryObject queryObject)
        {
            Check.IsNotNull(queryObject);

            return await _masterDataHttpClient.GetDimensionStructureByIdAsync(queryObject)
               .ConfigureAwait(false);
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            return await _masterDataHttpClient.GetDimensionStructuresAsync().ConfigureAwait(false);
        }
    }

    public interface IDimensionStructureTreeComponentService
    {
        Task<DimensionStructure> GetDimensionStructureById(DimensionStructureQueryObject queryObject);

        Task<List<DimensionStructure>> GetDimensionStructuresAsync();
    }
}