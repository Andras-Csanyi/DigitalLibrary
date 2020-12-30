namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// Http Client interface for <see cref="IDimensionStructureNode"/> objects.
    /// </summary>
    public interface IDimensionStructureNodeHttpClient
    {
        /// <summary>
        /// Calls Add method of <see cref="DimensionStructureNode"/> REST Api and POSTs
        /// the payload.
        /// </summary>
        /// <param name="dimensionStructureNode">
        /// The object contains the properties of the new object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> which contains a <see cref="DilibHttpClientResponse{T}" /> enclosing
        ///     the result.
        ///     In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}" /> other
        ///     properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructureNode>> AddAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default);
    }
}