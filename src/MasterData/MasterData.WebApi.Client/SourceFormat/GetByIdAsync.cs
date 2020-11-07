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
        public async Task<DilibHttpClientResponse<SourceFormat>> GetByIdAsync(
            SourceFormat getById,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(getById);
            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.GetById}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PostAsync(getById, url, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}