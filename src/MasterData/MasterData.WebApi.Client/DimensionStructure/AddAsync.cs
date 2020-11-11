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
        public async Task<DilibHttpClientResponse<DimensionStructure>> AddAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/{MasterDataApi.DimensionStructure.V1.Add}";
            DilibHttpClientResponse<DimensionStructure> result = await _diLibHttpClient
               .PostAsync<DimensionStructure>(dimensionStructure, url, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}