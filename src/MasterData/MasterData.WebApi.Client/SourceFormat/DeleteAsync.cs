namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<SourceFormat>> DeleteAsync(
            SourceFormat tobeDeleted,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.SourceFormat.BasePath}/{MasterDataApi.SourceFormat.V1.Delete}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .DeleteAsync(url, tobeDeleted, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}
