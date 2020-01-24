namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    using Web.Api;

    public partial class MasterDataHttpClient : IMasterDataHttpClient
    {
        public async Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                string url = $"{MasterDataApi.SourceFormat.SourceFormatBase}/" +
                             $"{MasterDataApi.SourceFormat.V1.Update}";
                SourceFormat result = await _diLibHttpClient.PutAsync(sourceFormat, url)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            try
            {
                string url = $"{MasterDataApi.SourceFormat.SourceFormatBase}/" +
                             $"{MasterDataApi.SourceFormat.V1.GetAll}";
                List<SourceFormat> result = await _diLibHttpClient.GetAsync<List<SourceFormat>>(url)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task DeleteSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                string url = $"{MasterDataApi.SourceFormat.SourceFormatBase}/" +
                             $"{MasterDataApi.SourceFormat.V1.Delete}";
                await _diLibHttpClient.DeleteAsync(sourceFormat, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }

        public async Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                string url = $"{MasterDataApi.SourceFormat.SourceFormatBase}/" +
                             $"{MasterDataApi.SourceFormat.V1.Add}";
                return await _diLibHttpClient.PostAsync(sourceFormat, url).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataHttpClientException(e.Message, e);
            }
        }
    }
}