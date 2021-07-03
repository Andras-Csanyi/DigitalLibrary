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
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<DimensionStructureNode>> CreateDimensionStructureNodeAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(dimensionStructureNode);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.CreateDimensionStructureNode}";
            DilibHttpClientResponse<DimensionStructureNode> result = await _diLibHttpClient
               .PostAsync(url, dimensionStructureNode, cancellationToken)
               .ConfigureAwait(false);

            return result;
        }
    }
}
