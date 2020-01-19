using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
    using DomainModel;

    using Web.Api;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        public async Task<DimensionStructure> ModifyTopDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.UpdateTopDimensionStructure}";
                DimensionStructure result = await _diLibHttpClient.Put(dimensionStructure, url)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<List<DimensionStructure>> GetTopDimensionStructuresAsync()
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.GetTopDimensionStructures}";
                List<DimensionStructure> result = await _diLibHttpClient.Get<List<DimensionStructure>>(url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task DeleteTopDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.DeleteTopDimensionStructure}";
                await _diLibHttpClient.Delete(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<DimensionStructure> AddTopDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                    $"{MasterDataApi.DimensionStructure.V1.AddTopDimensionStructure}";
                return await _diLibHttpClient.Post(dimensionStructure, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }
    }
}