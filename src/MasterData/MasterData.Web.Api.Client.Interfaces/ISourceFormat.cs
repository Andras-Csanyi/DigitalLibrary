// <copyright file="IMasterDataHttpClient.Sourceformat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api.Client.Exceptions;
    using DigitalLibrary.MasterData.WebApi.Client.ResponseObjects;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// Interface for HttpClient communicates with SourceFormat endpoint.
    /// </summary>
    public interface ISourceFormat
    {
        /// <summary>
        /// Sends the payload to the SourceFormat Endpoint AddAsync method.
        /// </summary>
        /// <param name="sourceFormat">
        ///    <see cref="SourceFormat"/> object going to be added to the system.
        ///    </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        ///    Returns with <see cref="Task{TResult}"/> representing result of asynchronous operation.
        /// It includes a <see cref="DilibHttpClientResponse{T}"/> which contains the result or the error
        /// happened during the operation.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormat>> AddAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends the payload to SourceFormat endpoint's UpdateAsync method.
        /// Http method is Update.
        /// </summary>
        /// <param name="sourceFormat">
        /// Object represents the object to be modified and the changed data.
        /// Id identifies the object to be modified. The remaining parameters representing the new data.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing the result of asynchronous operation.
        /// It contains a <see cref="DilibHttpClientResponse{T}"/> which encloses in case of successful operation
        /// the result in the <see cref="DilibHttpClientResponse{T}.Result"/> property.
        /// In case of unsuccessful operation other properties contain details.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormat>> UpdateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default);
    }
}