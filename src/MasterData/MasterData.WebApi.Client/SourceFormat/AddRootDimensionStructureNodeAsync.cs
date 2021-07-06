namespace DigitalLibrary.MasterData.WebApi.Client.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    public partial class SourceFormatHttpClientHttpClient
    {
        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<SourceFormat>> AddRootDimensionStructureNodeAsync(
            AddRootDimensionStructureNodeViewModel addRootDimensionStructureNodeViewModel,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(addRootDimensionStructureNodeViewModel);

            string url = $"{SourceFormatBase}/{MasterDataApi.SourceFormat.V1.AddRootDimensionStructureNode}";
            DilibHttpClientResponse<SourceFormat> result = await _diLibHttpClient
               .PostAsync<SourceFormat, AddRootDimensionStructureNodeViewModel>(
                    url,
                    addRootDimensionStructureNodeViewModel,
                    cancellationToken
                )
               .ConfigureAwait(false);

            return result;
        }
    }
}
