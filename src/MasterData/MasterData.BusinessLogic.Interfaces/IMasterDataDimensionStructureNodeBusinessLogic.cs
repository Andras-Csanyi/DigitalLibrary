namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    /// Interface for MasterDataDimensionStructureNodeBusinessLogic describing
    /// available operations in Master Data context.
    /// </summary>
    public interface IMasterDataDimensionStructureNodeBusinessLogic
    {
        /// <summary>
        /// Creates a root node and attaches to <see cref="SourceFormat"/>. It returns with the newly
        /// created <see cref="DimensionStructureNode"/>.
        /// </summary>
        /// <param name="sourceFormat">
        /// The <see cref="SourceFormat"/> object which will have the root node.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of asynchronous operation.
        /// It includes a <see cref="DimensionStructureNode"/> which is the created and attached node.
        /// </returns>
        Task<DimensionStructureNode> CreateRootNodeAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);
    }
}