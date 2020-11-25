// <copyright file="IDiLibHttpClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System.Threading;
    using System.Threading.Tasks;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    ///     DiLib Http Client interface.
    /// </summary>
    public interface IDiLibHttpClient
    {
        /// <summary>
        ///     It sends the payload to url using DELETE http verb.
        /// </summary>
        /// <param name="url">The url which will be hit by DELETE http verb.</param>
        /// <param name="payload">
        ///     <see cref="T" /> type object which represents or contains data about the object to be deleted.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <returns>
        ///     Returns <see cref="Task{TResult}" /> representing result of an asynchronous operation.
        /// </returns>
        Task<DilibHttpClientResponse<T>> DeleteAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        ///     It calls url via GET http verb.
        /// </summary>
        /// <param name="url">The url will be hit by GET verb.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 with content where type is T.</returns>
        Task<DilibHttpClientResponse<T>> GetAsync<T>(
            string url,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Posts payload to given url, where http method is POST.
        /// </summary>
        /// <param name="url">The url where to the object will be posted.</param>
        /// <param name="payload">Object to be posted.</param>
        /// <param name="cancellationToken">
        ///     <see cref="CancellationToken" />
        /// </param>
        /// <typeparam name="T">Type will be posted, and the return result Type too.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 and content where type is T.</returns>
        /// <exception cref="DiLibHttpException">
        ///     Any error happen.
        /// </exception>
        Task<DilibHttpClientResponse<T>> PostAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        ///     Posts payload to given url, where http method is POST.
        /// </summary>
        /// <param name="url">The url where the payload going to be sent to.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <typeparam name="TReturnType">Generic ReturnType.</typeparam>
        /// <typeparam name="TPayloadType">Generic PayloadType.</typeparam>
        /// <returns>HttpResponseMessage with Status 200, content type is TReturnType.</returns>
        Task<TReturnType> PostAsync<TReturnType, TPayloadType>(
            string url,
            TPayloadType payload,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Sends <see cref="T" /> type payload to the given url via PUT http verb.
        /// </summary>
        /// <param name="url">The url where to payload will be sent.</param>
        /// <param name="payload">Payload object.</param>
        /// <typeparam name="T">Type of payload and result type.</typeparam>
        /// <returns>
        ///     Returns <see cref="Task{TResult}" /> representing result of an asynchronous operation.
        ///     It contains a <see cref="DilibHttpClientResponse{T}" /> object where its Result property contains the
        ///     operation result in case of success.
        ///     In case of any error other properties of the result object provides further information about the error.
        /// </returns>
        Task<DilibHttpClientResponse<T>> PutAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class;
    }
}