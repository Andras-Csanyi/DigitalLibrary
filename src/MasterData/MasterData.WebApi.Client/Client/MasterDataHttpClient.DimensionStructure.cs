using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    using DomainModel;

    using Web.Api;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        public async Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.UpdateDimensionStructure}";
                DimensionStructure result = await _diLibHttpClient.Put(dimensionStructure, url)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.GetDimensionStructures}";
                List<DimensionStructure> result = await _diLibHttpClient.Get<List<DimensionStructure>>(url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.DeleteDimensionStructure}";
                await _diLibHttpClient.Delete(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.AddDimensionStructure}";
                return await _diLibHttpClient.Post(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }
    }
}