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
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<DimensionStructure>> UpdateAsync(
            DimensionStructure payload,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(payload);
            string url = $"{MasterDataApi.DimensionStructure.RouteBase}/{MasterDataApi.DimensionStructure.V1.Update}";
            DilibHttpClientResponse<DimensionStructure> result = await _diLibHttpClient
               .PutAsync<DimensionStructure>(url, payload, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}