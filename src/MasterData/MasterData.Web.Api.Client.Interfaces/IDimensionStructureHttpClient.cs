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
    }
}