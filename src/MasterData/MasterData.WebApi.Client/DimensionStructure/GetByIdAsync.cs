namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructure
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    public partial class DimensionStructureHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<DimensionStructure>> GetByIdAsync(
            DimensionStructure requested,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(requested);
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/{MasterDataApi.DimensionStructure.V1.GetById}";
            DilibHttpClientResponse<DimensionStructure> result = await _diLibHttpClient
               .PostAsync<DimensionStructure>(url, requested, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
