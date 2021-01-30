namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    ///     Interface for MasterDataDimensionStructureNodeBusinessLogic describing
    ///     available operations in Master Data context.
    /// </summary>
    public interface IMasterDataDimensionStructureNodeBusinessLogic
    {
        /// <summary>
        ///     Creates a root node and attaches to <see cref="SourceFormat" />. It returns with the newly
        ///     created <see cref="DimensionStructureNode" />.
        /// </summary>
        /// <param name="sourceFormat">
        ///     The <see cref="SourceFormat" /> object which will have the root node.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns <see cref="Task{TResult}" /> representing result of asynchronous operation.
        ///     It includes a <see cref="DimensionStructureNode" /> which is the created and attached node.
        /// </returns>
        /// <exception cref="MasterDataDimensionStructureNodeBusinessLogicException">
        ///     Whatever issue happens.
        /// </exception>
        Task<DimensionStructureNode> CreateRootNodeAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Deletes a root node and as a result a given <see cref="SourceFormat" /> lost
        ///     its root <see cref="DimensionStructureNode" />.
        /// </summary>
        /// <param name="sourceFormat">
        ///     The <see cref="SourceFormat" /> where the <see cref="DimensionStructureNode" /> is attached to
        ///     as root node.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns <see cref="Task{TResult}" /> representing result of asynchronous operation.
        /// </returns>
        /// <exception cref="MasterDataDimensionStructureNodeBusinessLogicException">
        ///     Whatever issue happens.
        /// </exception>
        Task DeleteRootDimensionStructureNodeOfSourceFormatAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Creates a <see cref="DimensionStructureNode" />.
        /// </summary>
        /// <param name="dimensionStructureNode">
        ///     The object contains the date of new <see cref="DimensionStructureNode" />.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns <see cref="Task{TResult}" /> representing result of async operation.
        ///     It contains the newly created <see cref="DimensionStructureNode" /> object.
        /// </returns>
        /// <exception cref="MasterDataDimensionStructureNodeBusinessLogicException">
        ///     Whatever issue happens.
        /// </exception>
        Task<DimensionStructureNode> AddAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default);
    }
}