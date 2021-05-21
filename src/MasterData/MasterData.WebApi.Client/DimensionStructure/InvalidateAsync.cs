namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructure
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class DimensionStructureHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<DimensionStructure>> InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/" +
                         $"{MasterDataApi.DimensionStructure.V1.Inactivate}";
            DilibHttpClientResponse<DimensionStructure> result = await _diLibHttpClient
               .PutAsync<DimensionStructure>(url, dimensionStructure, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
