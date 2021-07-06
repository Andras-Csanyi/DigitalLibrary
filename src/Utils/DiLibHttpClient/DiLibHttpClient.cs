// <copyright file="DiLibHttpClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.Utils.Guards;

    using DiLibHttpClientResponseObjects;

    using Newtonsoft.Json;

    /// <inheritdoc/>
    public class DiLibHttpClient : IDiLibHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiLibHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"> Instance. </param>
        public DiLibHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> DeleteAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);

            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Delete, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();

                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    result.Exception = e;
                    result.ExceptionMessage = e.Message;
                    result.IsSuccess = false;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> GetAsync<T>(
            string url,
            CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmptyOrWhitespace(url);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string responseString = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);
                    T res = JsonToObject<T>(responseString);

                    result.Result = res;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    result.IsSuccess = false;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;
                    result.Exception = e;
                    result.ExceptionMessage = e.Message;

                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> PostAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);
            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(
                    httpRequestMessage,
                    cancellationToken)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string content = await httpResponseMessage
                       .Content
                       .ReadAsStringAsync(cancellationToken)
                       .ConfigureAwait(false);

                    T res = JsonToObject<T>(content);

                    result.Result = res;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    result.ExceptionMessage = e.Message;
                    result.Exception = e;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;
                    result.IsSuccess = false;

                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<TReturnType>> PostAsync<TReturnType, TPayloadType>(
            string url,
            TPayloadType payload,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);

            DilibHttpClientResponse<TReturnType> result = new DilibHttpClientResponse<TReturnType>();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string content = await httpResponseMessage
                       .Content
                       .ReadAsStringAsync(cancellationToken)
                       .ConfigureAwait(false);
                    TReturnType res = JsonToObject<TReturnType>(content);
                    result.Result = res;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;
                    return result;
                }
                catch (Exception e)
                {
                    result.ExceptionMessage = e.Message;
                    result.Exception = e;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;
                    result.IsSuccess = false;
                    return result;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<DilibHttpClientResponse<T>> PutAsync<T>(
            string url,
            T payload,
            CancellationToken cancellationToken = default)
            where T : class
        {
            Check.IsNotNull(payload);
            Check.NotNullOrEmptyOrWhitespace(url);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Put, url);
            httpRequestMessage.Content = CreateStringContent(payload);

            DilibHttpClientResponse<T> result = new DilibHttpClientResponse<T>();

            using (HttpResponseMessage httpResponseMessage = await _httpClient
               .SendAsync(httpRequestMessage, cancellationToken)
               .ConfigureAwait(false))
            {
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();

                    string resultString = await httpResponseMessage.Content.ReadAsStringAsync()
                       .ConfigureAwait(false);
                    T resulToObject = JsonToObject<T>(resultString);

                    result.Result = resulToObject;
                    result.IsSuccess = true;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
                catch (Exception e)
                {
                    result.Exception = e;
                    result.ExceptionMessage = e.Message;
                    result.IsSuccess = false;
                    result.HttpStatusCode = (int)httpResponseMessage.StatusCode;

                    return result;
                }
            }
        }

        private StringContent CreateStringContent<T>(T payload)
        {
            string payloadString = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            StringContent stringContent = new StringContent(payloadString, Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
            return stringContent;
        }

        private T JsonToObject<T>(string stringContent)
        {
            T result = JsonConvert.DeserializeObject<T>(stringContent, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            return result;
        }
    }
}
