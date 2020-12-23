namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatHttpClientHttpClient
    {
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<List<SourceFormat>>> GetInactives(
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.SourceFormat.BasePath}/{MasterDataApi.SourceFormat.V1.GetInActives}";
            DilibHttpClientResponse<List<SourceFormat>> result = await _diLibHttpClient
               .GetAsync<List<SourceFormat>>(url, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}