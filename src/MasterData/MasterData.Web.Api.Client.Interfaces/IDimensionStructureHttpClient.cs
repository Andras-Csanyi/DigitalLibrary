// <copyright file="IMasterDataHttpClient.DimensionStructure.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api.Client.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// DimensionStructure business logic interface.
    /// </summary>
    public interface IDimensionStructureHttpClient
    {
        /// <summary>
        /// Sends the provided object to AddAsync method of DimensionStructure endpoint
        /// via Http protocol's POST verb.
        /// </summary>
        /// <param name="dimensionStructure">
        /// The object going to be recorded in the database.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructure>> AddAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a <see cref="DimensionStructure"/> object based on Id.
        /// </summary>
        /// <param name="requested">
        ///    It represents the DimensionStructure should be returned. Only the Id property concerned,
        /// any other property is ignored. 
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructure>> GetByIdAsync(
            DimensionStructure requested,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates <see cref="DimensionStructure"/>.
        ///
        /// The payload object Id value marks which <see cref="DimensionStructure"/> object is going to be
        /// updated.
        /// </summary>
        /// <param name="payload">
        /// <see cref="DimensionStructure"/> which holds the new data.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructure>> UpdateAsync(
            DimensionStructure payload,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries all <see cref="DimensionStructure"/>s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<List<DimensionStructure>>> GetAllAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries all active <see cref="DimensionStructure"/>s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<List<DimensionStructure>>> GetActivesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries all inactive <see cref="DimensionStructure"/>s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<List<DimensionStructure>>> GetInActivesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a <see cref="DimensionStructure"/>.
        /// </summary>
        /// <param name="dimensionStructure">
        /// A <see cref="DimensionStructure"/> where the ID marks which
        /// item will be deleted.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructure>> DeleteAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Inactivates a <see cref="DimensionStructure"/>.
        /// </summary>
        /// <param name="dimensionStructure">
        /// The payload <see cref="DimensionStructure"/> object where the ID value marks which object
        /// should be invalidated. Every other property is ignored.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>
        /// Returns a <see cref="Task{TResult}"/> which contains a <see cref="DilibHttpClientResponse{T}"/> enclosing
        /// the result.
        /// In case of any error the other properties of the <see cref="DilibHttpClientResponse{T}"/> other
        /// properties provide further information about the error details.
        /// </returns>
        Task<DilibHttpClientResponse<DimensionStructure>> InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default);
    }
}