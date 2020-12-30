namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    /// <summary>
    /// Interface which describes business logic functions for SourceFormatDimensionStructureNode entities.
    /// </summary>
    public interface IMasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        /// <summary>
        /// Adds new <see cref="SourceFormatDimensionStructureNode"/>.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        ///    <see cref="SourceFormatDimensionStructureNode"/> which contains the new values.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// It includes a <see cref="SourceFormatDimensionStructureNode"/> object which is the result of the
        /// operation.
        /// </returns>
        /// <exception cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException">
        /// When any error happens.
        /// </exception>
        Task<SourceFormatDimensionStructureNode> AddAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a <see cref="SourceFormatDimensionStructureNode"/>.
        ///
        /// By deleting a <see cref="SourceFormatDimensionStructureNode"/> the connection between a <see cref="SourceFormat"/>
        /// and <see cref="DimensionStructure"/> is removed.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        /// The node going to be deleted. Only the id value is validated.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of async operation.
        /// </returns>
        /// <exception cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException">
        /// When any error happens.
        /// </exception>
        Task DeleteAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns with a single <see cref="SourceFormatDimensionStructureNode"/> based on id.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        /// The object which contains the id value for finding the given item.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of async operation.
        /// It contains the given item or null.
        /// </returns>
        /// <exception cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException">
        /// When any error happens.
        /// </exception>
        Task<SourceFormatDimensionStructureNode> GetByIdAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an <see cref="SourceFormatDimensionStructureNode"/> object and returns
        /// the updated version.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        /// The object contains the new values. Id identifies the object, other properties contains the new value.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of async operation. It also includes
        /// the <see cref="SourceFormatDimensionStructureNode"/> object.
        /// </returns>
        /// </returns>
        /// <exception cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogicException">
        /// When any error happens.
        /// </exception>
        Task<SourceFormatDimensionStructureNode> UpdateAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);
    }
}