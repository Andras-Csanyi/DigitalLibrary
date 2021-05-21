namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<SourceFormat>> InactivateAsync(
            SourceFormat toBeInactivated,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(toBeInactivated);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.Inactivate}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PostAsync(url, toBeInactivated, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}
