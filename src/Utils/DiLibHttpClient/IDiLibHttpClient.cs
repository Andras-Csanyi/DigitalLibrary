namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System.Threading.Tasks;

    public interface IDiLibHttpClient
    {
        /// <summary>
        /// Posts payload to given url, where http method is POST.
        /// </summary>
        /// <param name="payload">Object to be posted</param>
        /// <param name="url">The url where to the object will be posted</param>
        /// <typeparam name="T">Type will be posted, and the return result Type too.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 and content where type is T.</returns>
        Task<T> PostAsync<T>(T payload, string url) where T : class;

        Task<ReturnType> PostAsync<ReturnType, PayloadType>(PayloadType payload, string url);

        /// <summary>
        /// It sends the payload to url using DELETE http verb.
        /// </summary>
        /// <param name="payload">The object which will be sent via DELETE http verb.</param>
        /// <param name="url">The url which will be hit by DELETE http verb.</param>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <returns>HttpResponseMessage with Status 200, if error happened then Status 400.</returns>
        Task DeleteAsync<T>(T payload, string url) where T : class;

        /// <summary>
        /// It calls url via GET http verb.
        /// </summary>
        /// <param name="url">The url will be hit by GET verb.</param>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <returns>HttpResponseMessage with Status 200 with content where type is T.</returns>
        Task<T> GetAsync<T>(string url);

        /// <summary>
        /// Payload will be sent to url via PUT http verb.
        /// </summary>
        /// <param name="payload">Payload object.</param>
        /// <param name="url">The url where to payload will be sent.</param>
        /// <typeparam name="T">Type of payload and result type.</typeparam>
        /// <returns>HttpResponseMessage with Status 200, content type is T.</returns>
        Task<T> PutAsync<T>(T payload, string url) where T : class;
    }
}