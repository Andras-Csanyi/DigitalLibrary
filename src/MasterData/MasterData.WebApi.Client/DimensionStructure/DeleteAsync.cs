namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructure
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class DimensionStructureHttpClientHttpClient
    {
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<DimensionStructure>> DeleteAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/{MasterDataApi.DimensionStructure.V1.Delete}";
            DilibHttpClientResponse<DimensionStructure> result = await _diLibHttpClient
               .DeleteAsync(url, dimensionStructure, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}