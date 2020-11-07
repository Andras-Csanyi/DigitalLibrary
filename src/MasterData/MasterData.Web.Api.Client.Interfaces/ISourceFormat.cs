// <copyright file="IMasterDataHttpClient.Sourceformat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    using System.Collections.Generic;
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

        /// <summary>
        /// Sends the payload to SourceFormat endpoint's InactivateAsync method.
        /// Http method is PUT.
        /// </summary>
        /// <param name="toBeInactivated">
        /// It represents the object we would like to have inactivated.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing the result of asynchronous operation.
        /// It contains a <see cref="DilibHttpClientResponse{T}"/> which encloses in case of successful operation
        /// the result in the <see cref="DilibHttpClientResponse{T}.Result"/> property.
        /// In case of unsuccessful operation other properties contain details.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormat>> InactivateAsync(
            SourceFormat toBeInactivated,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests a <see cref="SourceFormat"/> object identified by the provided payload Id value.
        /// Communication happens via http POST method.
        /// </summary>
        /// <param name="getById">
        /// A <see cref="SourceFormat"/> object where the ID identifies the requested object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> representing the result of an asynchronous operation.
        /// It encloses a <see cref="DilibHttpClientResponse{T}"/> where the Result property is null since
        /// Inactivate operation doesn't return value.
        /// In case of failure other properties provide further details of the error.
        /// </returns>
        Task<DilibHttpClientResponse<SourceFormat>> GetByIdAsync(
            SourceFormat getById,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests list of <see cref="SourceFormat"/>s.
        /// It returns all available <see cref="SourceFormat"/>s in the system independently whether they are
        /// actives of inactives.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of an asynchronous operation.
        /// It contains the result of the operation in the Result property.
        /// In case of error, other properties of the <see cref="DilibHttpClientResponse{T}"/> object provides
        /// further information about the error.
        /// </returns>
        Task<DilibHttpClientResponse<List<SourceFormat>>> GetAllAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests list of inactive <see cref="SourceFormat"/>s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of an asynchronous operation.
        /// It contains the result of the operation in the Result property.
        /// In case of error, other properties of the <see cref="DilibHttpClientResponse{T}"/> object provides
        /// further information about the error.
        /// </returns>
        Task<DilibHttpClientResponse<List<SourceFormat>>> GetInactives(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests list of active <see cref="SourceFormat"/>s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of an asynchronous operation.
        /// It contains the result of the operation in the Result property.
        /// In case of error, other properties of the <see cref="DilibHttpClientResponse{T}"/> object provides
        /// further information about the error.
        /// </returns>
        Task<DilibHttpClientResponse<List<SourceFormat>>> GetActives(
            CancellationToken cancellationToken = default);
    }
}