namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormatDimensionStructureNode
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatDimensionStructureNodeHttpClient
    {
        /// <inheritdoc />
        public async Task<DilibHttpClientResponse<SourceFormatDimensionStructureNode>> DeleteAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            string url = $"{MasterDataApi.SourceFormatDimensionStructureNode.BasePath}/" +
                         $"{MasterDataApi.SourceFormatDimensionStructureNode.V1.Delete}";
            DilibHttpClientResponse<SourceFormatDimensionStructureNode> result = await _dilibHttpClient
               .DeleteAsync(url, sourceFormatDimensionStructureNode, cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}