namespace DigitalLibrary.MasterData.WebApi.Client.DimensionStructureNode
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class DimensionStructureNodeHttpClient
    {
        public async Task<DilibHttpClientResponse<DimensionStructureNode>> AddAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.DimensionStructureNode.BasePath}/" +
                         $"{MasterDataApi.DimensionStructureNode.V1.Add}";
            DilibHttpClientResponse<DimensionStructureNode> result = await _dilibHttpClient
               .PostAsync(url, dimensionStructureNode, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
