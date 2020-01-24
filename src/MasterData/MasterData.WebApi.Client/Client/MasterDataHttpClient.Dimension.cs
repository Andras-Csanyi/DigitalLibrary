namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    using Web.Api;

    public partial class MasterDataHttpClient
    {
        public async Task<List<Dimension>> GetDimensionsAsync()
        {
            try
            {
                string url = $"{MasterDataApi.Dimensions.V1.DimensionRouteBase}/" +
                             $"{MasterDataApi.Dimensions.V1.GetAllActive}";
                List<Dimension> result = await _diLibHttpClient.Get<List<Dimension>>(url).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<Dimension> AddDimensionAsync(Dimension dimension)
        {
            try
            {
                string url = $"{MasterDataApi.Dimensions.V1.DimensionRouteBase}/" +
                             $"{MasterDataApi.Dimensions.V1.AddNew}";
                Dimension result = await _diLibHttpClient.Post(dimension, url).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<List<Dimension>> GetDimensionsWithoutStructure()
        {
            try
            {
                string url = $"{MasterDataApi.Dimensions.V1.DimensionRouteBase}/" +
                             $"{MasterDataApi.Dimensions.V1.GetDimensionsWithoutStructure}";
                List<Dimension> result = await _diLibHttpClient.Get<List<Dimension>>(url).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task DeleteDimensionAsync(Dimension dimension)
        {
            try
            {
                string url = $"{MasterDataApi.Dimensions.V1.DimensionRouteBase}/" +
                             $"{MasterDataApi.Dimensions.V1.Delete}";
                await _diLibHttpClient.Delete(dimension, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<Dimension> UpdateDimensionAsync(Dimension dimension)
        {
            try
            {
                string url = $"{MasterDataApi.Dimensions.V1.DimensionRouteBase}/" +
                             $"{MasterDataApi.Dimensions.V1.Modify}";
                Dimension result = await _diLibHttpClient.Put(dimension, url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<DimensionStructure> UpdateDimensionStructure(DimensionStructure updatedDimensionStructure)
        {
            try
            {
                string url = $"{MasterDataApi.DimensionStructure.V1.DimensionStructureBase}/" +
                             $"{MasterDataApi.DimensionStructure.V1.UpdateDimensionStructure}";
                DimensionStructure result = await _diLibHttpClient.Put(updatedDimensionStructure, url)
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