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
        Task<SourceFormatDimensionStructureNode> AddAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);
    }
}