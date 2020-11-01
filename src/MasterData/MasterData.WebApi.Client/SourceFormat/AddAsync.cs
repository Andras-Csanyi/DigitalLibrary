namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.MasterData.Web.Api.Client.Exceptions;
    using DigitalLibrary.Utils.Guards;

    using Newtonsoft.Json;

    public partial class SourceFormatHttpClient
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> AddAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sourceFormat);

                string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.Add}";
                SourceFormat result = await _diLibHttpClient
                   .PostAsync(sourceFormat, url, cancellationToken)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataHttpClient)}." +
                             $"{nameof(SourceFormatHttpClient)}." +
                             $"{nameof(AddAsync)} operation failed. " +
                             $"For further information see inner exception!";
                throw new MasterDataHttpClientException(msg, e);
            }
        }
    }
}