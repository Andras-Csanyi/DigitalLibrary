namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class DimensionStructureHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<List<DimensionStructure>>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/{MasterDataApi.DimensionStructure.V1.GetAll}";
            DilibHttpClientResponse<List<DimensionStructure>> result = await _diLibHttpClient
               .GetAsync<List<DimensionStructure>>(url, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}
