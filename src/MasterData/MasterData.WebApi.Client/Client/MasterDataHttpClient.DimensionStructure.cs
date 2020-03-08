using DimensionStructureQueryObject = DigitalLibrary.MasterData.BusinessLogic.ViewModels.DimensionStructureQueryObject;

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    using Web.Api;

    public partial class MasterDataHttpClient
    {
        /// <inheritdoc />
        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.GetDimensionStructures}";
                List<DimensionStructure> result = await _diLibHttpClient.GetAsync<List<DimensionStructure>>(url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync(
            DimensionStructureQueryObject queryObject)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.GetDimensionStructuresByIds}";
                List<DimensionStructure> result = await _diLibHttpClient
                   .PostAsync<List<DimensionStructure>, DimensionStructureQueryObject>(queryObject, url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.GetDimensionStructureById}";
                DimensionStructure result = await _diLibHttpClient
                   .PostAsync<DimensionStructure, DimensionStructureQueryObject>(dimensionStructureQueryObject, url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        /// <inheritdoc />
        public async Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.DeleteDimensionStructure}";
                await _diLibHttpClient.DeleteAsync(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        /// <inheritdoc />
        public async Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.AddDimensionStructure}";
                return await _diLibHttpClient.PostAsync(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.UpdateDimensionStructure}";
                DimensionStructure result = await _diLibHttpClient.PutAsync(dimensionStructure, url)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }
    }
}