namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// Http Client interface for <see cref="SourceFormatDimensionStructureNode"/> object.
    /// </summary>
    public interface ISourceFormatDimensionStructureNodeHttpClient
    {
        /// <summary>
        /// Adding a <see cref="SourceFormatDimensionStructureNode"/> object.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        /// The object contains the details of the new object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> which contains a <see cref="DilibHttpClientResponse{T}" /> enclosing
        ///     the result.
        ///     In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}" /> other
        ///     properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormatDimensionStructureNode>> AddAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a <see cref="SourceFormatDimensionStructureNode"/> object.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        /// The object contains the new properties of the object should be updated.
        /// The Id property identifies which object should be updated.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> which contains a <see cref="DilibHttpClientResponse{T}" /> enclosing
        ///     the result.
        ///     In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}" /> other
        ///     properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormatDimensionStructureNode>> UpdateAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default);
    }
}