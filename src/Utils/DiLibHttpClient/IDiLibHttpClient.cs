// <copyright file="IDiLibHttpClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System.Threading;
    using System.Threading.Tasks;

    using DiLibHttpClientResponseObjects;

    /// <summary>
    /// DiLib Http Client interface.
    /// </summary>
    public interface IDiLibHttpClient
    {
        /// <summary>
        ///     It sends the payload to url using DELETE http verb.
        /// </summary>
        /// <param name="payload">The object which will be sent via DELETE http verb.</param>
        /// <param name="url">The url which will be hit by DELETE http verb.</param>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <returns>HttpResponseMessage with Status 200, if error happened then Status 400.</returns>
        Task DeleteAsync<T>(T payload, string url)
            where T : class;

        /// <summary>
        ///     It calls url via GET http verb.
        /// </summary>
        /// <param name="url">The url will be hit by GET verb.</param>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 with content where type is T.</returns>
        Task<T> GetAsync<T>(string url);

        /// <summary>
        ///     Posts payload to given url, where http method is POST.
        /// </summary>
        /// <param name="payload">Object to be posted.</param>
        /// <param name="url">The url where to the object will be posted.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <typeparam name="T">Type will be posted, and the return result Type too.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 and content where type is T.</returns>
        /// <exception cref="DiLibHttpException">
        ///    Any error happen.
        /// </exception>
        Task<DilibHttpClientResponse<T>> PostAsync<T>(T payload,
                                                      string url,
                                                      CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        /// Posts payload to given url, where http method is POST.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <param name="url">The url where the payload going to be sent to.</param>
        /// <typeparam name="TReturnType">Generic ReturnType.</typeparam>
        /// <typeparam name="TPayloadType">Generic PayloadType.</typeparam>
        /// <returns>HttpResponseMessage with Status 200, content type is TReturnType.</returns>
        Task<TReturnType> PostAsync<TReturnType, TPayloadType>(TPayloadType payload, string url);

        /// <summary>
        ///     Sends <see cref="T"/> type payload to the given url via PUT http verb.
        /// </summary>
        /// <param name="payload">Payload object.</param>
        /// <param name="url">The url where to payload will be sent.</param>
        /// <typeparam name="T">Type of payload and result type.</typeparam>
        /// <returns>
        /// Returns <see cref="Task{TResult}"/> representing result of an asynchronous operation.
        /// It contains a <see cref="DilibHttpClientResponse{T}"/> object where its Result property contains the
        /// operation result in case of success.
        /// In case of any error other properties of the result object provides further information about the error.
        /// </returns>
        Task<DilibHttpClientResponse<T>> PutAsync<T>(
            T payload,
            string url,
            CancellationToken cancellationToken = default)
            where T : class;
    }
}