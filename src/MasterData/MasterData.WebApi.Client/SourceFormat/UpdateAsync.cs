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
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<SourceFormat>> UpdateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(sourceFormat);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.Update}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PutAsync(url, sourceFormat, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}