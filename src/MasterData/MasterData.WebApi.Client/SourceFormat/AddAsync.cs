namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.MasterData.Web.Api.Client.Exceptions;
    using DigitalLibrary.MasterData.WebApi.Client.ResponseObjects;
    using DigitalLibrary.Utils.DiLibHttpClient;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using Newtonsoft.Json;

    public partial class SourceFormatHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<SourceFormat>> AddAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(sourceFormat);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.Add}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PostAsync(sourceFormat, url, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}