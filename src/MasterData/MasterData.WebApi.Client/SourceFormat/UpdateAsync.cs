namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatHttpClient
    {
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<SourceFormat>> UpdateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(sourceFormat);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.Update}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PutAsync(sourceFormat, url, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}