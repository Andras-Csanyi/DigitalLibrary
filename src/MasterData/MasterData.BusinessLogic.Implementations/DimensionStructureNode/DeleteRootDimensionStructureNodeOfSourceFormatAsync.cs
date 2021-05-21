namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task DeleteRootDimensionStructureNodeOfSourceFormatAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
